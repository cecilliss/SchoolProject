using SchoolProject.Filters.Authentication;
using SchoolProject.Models;
using SchoolProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.Controllers
{
    public class SubjectsController : ApiController
    {
        private ISubjectService subjectService;
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IGradeService gradeService;

        public SubjectsController(ISubjectService subjectService,IStudentService studentService,ITeacherService teacherService, IGradeService gradeService)
        {
            this.subjectService = subjectService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.gradeService = gradeService;
        }

        [Route("school/subjects")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Subject> Get()
        {
            return subjectService.GetAllSubjects();
        }

        [Route("school/subjects/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetSubject(int id)
        {
            Subject subject = subjectService.GetSubject(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [Route("school/subjects")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostSubject(Subject subject)
        {
            Subject createdSubject = subjectService.CreateSubject(subject);
            return Created("", createdSubject);

        }

        [Route("school/subjects/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            Subject updatedSubject = subjectService.UpdateSubject(id, subject.Name, subject.WeeklyFond);

            if (updatedSubject == null)
            {
                return NotFound();
            }

            return Ok(updatedSubject);
        }

        [Route("school/subjects/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteSubject(int id)
        {
            Subject subject = subjectService.DeleteSubject(id);

            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [Route("school/subjects/findByStudent/{studentId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles ="admins, parents, students")]
        public IEnumerable<Subject> GetSubjectsByStudent(int studentId)
        {
            return studentService.GetSubjectsByStudent(studentId);
        }

        [Route("school/subjects/findByTeacher/{teacherId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles ="admins, teachers")]
        public IEnumerable<Subject>GetSubjectsByTeacher(int teacherId)
        {
            return teacherService.GetSubjectsByTeacher(teacherId);
        }

        [Route("school/subjects/{subjectId:int}/grades/{gradeId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles ="admins")]
        public IHttpActionResult PutSubjectsToGrades(int subjectId,int gradeId)
        {
            Subject subject = subjectService.GetSubject(subjectId);
            if (subject == null)
            {
                return NotFound();
            }

            Grade grade = gradeService.GetGrade(gradeId);
            if (grade == null)
            {
                return NotFound();
            }

            subject.Grades.Add(grade);
            grade.Subjects.Add(subject);

            subjectService.UpdateSubject(subjectId, subject.Name, subject.WeeklyFond);
            return Ok(subject);
        }

        [Route("school/subjects/findByGrade/{gradeId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Subject>GetSubjectsByGrade(int gradeId)
        {
            return gradeService.GetSubjectsByGrade(gradeId);
        }




    }
}
