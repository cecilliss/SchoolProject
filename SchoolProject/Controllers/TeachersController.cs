using SchoolProject.Filters.Authentication;
using SchoolProject.Models;
using SchoolProject.Models.DTO;
using SchoolProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.Controllers
{
    public class TeachersController : ApiController
    {
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        private IClassNumberService classNumberService;

        public TeachersController(ITeacherService teacherService,ISubjectService subjectService,IClassNumberService classNumberService)
        {
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.classNumberService = classNumberService;
        }

        [Route("school/teachers")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Teacher> Get()
        {
            return teacherService.GetAllTeachers();
        }

        [Route("school/teachers")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostTeacher(TeacherCreateDTO newTeacher)
        {
            Teacher teacher = new Teacher();
            teacher.FirstName = newTeacher.FirstName;
            teacher.LastName = newTeacher.LastName;
            teacher.Username = newTeacher.Username;
            teacher.Password = newTeacher.Password;
            teacher.Qualifications = newTeacher.Qualifications;
            teacher.YearsOfExperience = newTeacher.YearsOfExperience;
            teacher.Email = newTeacher.Email;

            if (newTeacher.RepeatedPassword != newTeacher.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }

            teacherService.CreateTeacher(teacher);
            return Created("", teacher);
        }

        [Route("school/teachers/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher teacher = teacherService.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [Route("school/teachers/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutTeacher(int id,TeacherCreateDTO teacher)
        {
            

            Teacher updatedTeacher = teacherService.UpdateTeacher(id,teacher.FirstName,teacher.LastName,teacher.Username,
                teacher.Password, teacher.Qualifications, teacher.YearsOfExperience, teacher.Email);

            if (updatedTeacher == null)
            {
                return NotFound();
            }
            if (teacher.RepeatedPassword != teacher.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }

            return Ok(updatedTeacher);
        }

        [Route("school/teachers/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteTeacher(int id)
        {
            Teacher teacher = teacherService.DeleteTeacher(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);


        }

        [Route("school/teachers/{teacherId:int}/subjects/{subjectId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutAddsTeachersToSubjects(int teacherId,int subjectId)
        {
            Teacher teacher = teacherService.GetTeacher(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }

            Subject subject = subjectService.GetSubject(subjectId);
            if (subject == null)
            {
                return NotFound();
            }

            teacher.Subjects.Add(subject);
            subject.Teachers.Add(teacher);

            teacherService.UpdateTeacher(teacherId, teacher.FirstName, teacher.LastName, teacher.Username, teacher.Password, teacher.Qualifications,
            teacher.YearsOfExperience, teacher.Email);

            return Ok(teacher);



        }

        [Route("school/teachers/{teacherId:int}/classNumbers/{classNumberId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutAddsTeachersToClasses(int teacherId,int classNumberId)
        {
            Teacher teacher = teacherService.GetTeacher(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }

            ClassNumber classNumber = classNumberService.GetClassNumber(classNumberId);
            if (classNumber == null)
            {
                return NotFound();
            }

            teacherService.UpdateTeacher(teacherId, teacher.FirstName, teacher.LastName, teacher.Username, teacher.Password, teacher.Qualifications,
                teacher.YearsOfExperience, teacher.Email);

            return Ok(teacher);
        }

        [Route("school/teachers/findBySubject/{subjectId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Teacher>GetTeachersBySubject(int subjectId)
        {
            return subjectService.GetTeachersBySubject(subjectId);
        }

        [Route("school/teachers/findByClassNumber/{classNumberId:int}")]
        public IEnumerable<Teacher>GetTeacherByClassNumber(int classNumberId)
        {
            return classNumberService.GetTeachersByClassNumber(classNumberId);
        }
    }
}
