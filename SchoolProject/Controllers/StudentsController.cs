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
    public class StudentsController : ApiController
    {
        private IStudentService studentService;
        private IParentService parentService;
        private IGradeService gradeService;
        private ISubjectService subjectService;
        private IMarkService markService;
        private IClassNumberService classNumberService;
        

        public StudentsController(IStudentService studentService,IParentService parentService,IGradeService gradeService,ISubjectService subjectService,IMarkService markService, IClassNumberService classNumberService)
        {
            this.studentService = studentService;
            this.parentService = parentService;
            this.gradeService = gradeService;
            this.subjectService = subjectService;
            this.markService = markService;
            this.classNumberService = classNumberService;
            
        }

        [Route("school/students")]
        [HttpGet]
        [Authorize(Roles="admins")]
        public IEnumerable<Student> Get()
        {
            return studentService.GetAllStudents();
        }

        [Route("school/students/{id:int}")]
        [HttpGet]
        [Authorize(Roles ="admins")]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Route("school/students")]
        [HttpPost]
        [Authorize(Roles ="admins")]
        public IHttpActionResult PostStudent(StudentCreateDTO newStudent)
        {
            Student student = new Student();
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.Username = newStudent.Username;
            student.Password = newStudent.Password;
            student.DateOfBirth = newStudent.DateOfBirth;
            student.YearOfEnrollement = newStudent.YearOfEnrollement;
            student.Gender = newStudent.Gender;

            if (newStudent.RepeatedPassword != newStudent.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }


            Student createdStudent = studentService.CreateStudent(student);
            return Created("", createdStudent);
        }
        [Route("school/students/{id:int}")]
        [HttpPut]
        [Authorize(Roles ="admins")]
        public IHttpActionResult PutStudent(int id,StudentCreateDTO student)
        {
           

            Student updatedStudent = studentService.UpdateStudent( id, student.FirstName,student.LastName,student.Username,
                student.Password,student.DateOfBirth,student.YearOfEnrollement,student.Gender);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            if (student.RepeatedPassword != student.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }


            return Ok(updatedStudent);
        }

        [Route("school/students/{id:int}")]
        [HttpDelete]
        [Authorize(Roles="admins")]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = studentService.DeleteStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [Route("school/students/{studentId:int}/grades/{gradeId:int}/classNumbers/{classNumberId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutAddsStudentsToGradeAndClassNumber(int studentId,int gradeId, int classNumberId)
        {
            Student student = studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }

            Grade grade = gradeService.GetGrade(gradeId);
            if (grade == null)
            {
                return NotFound();
            }

            ClassNumber classNumber = classNumberService.GetClassNumber(classNumberId);
            if (classNumber == null)
            {
                return NotFound();
            }

            student.Grade = grade;
            student.ClassNumber = classNumber;
            studentService.UpdateStudent(studentId,student.FirstName,student.LastName,student.Username,student.Password,
                student.DateOfBirth,student.YearOfEnrollement,student.Gender);
            return Ok(student);
        }


       


        [Route("school/students/{studentId:int}/subjects/{subjectId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles ="admins")]
        public IHttpActionResult PutAddsStubjectsToStudents(int subjectId, int studentId)
        {
            Student student = studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }

            Subject subject = subjectService.GetSubject(subjectId);
            if (subject == null)
            {
                return NotFound();
            }

            student.Subjects.Add(subject);
            subject.Students.Add(student);

            studentService.UpdateStudent(studentId, student.FirstName, student.LastName, student.Username, student.Password,
                student.DateOfBirth, student.YearOfEnrollement, student.Gender);

            return Ok(student);


        }

       

        [Route("school/students/findByParent/{parentId:int}")]
        [BasicAuthentication]
        [HttpGet]
        
        [Authorize(Roles ="admins,parents")]
        public IEnumerable<Student> GetStudentsByParent(int parentId)
        {
           

            return parentService.GetStudentsByParent(parentId);
        }

        [Route("school/students/findBySubject/{subjectId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Student> GetStudentsBySubject(int subjectId)
        {
            return subjectService.GetStudentsBySubject(subjectId);
        }

        [Route("school/students/findByGrade/{gradeId:int}/andClassNumber/{classNumberId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles ="admins,teachers")]
        public IEnumerable<Student> GetStudentsByGradeAndClassNumber(int gradeId,int classNumberId)
        {
            return gradeService.GetStudentsByGradeAndClassNumber(gradeId, classNumberId);
        }



    }
}
