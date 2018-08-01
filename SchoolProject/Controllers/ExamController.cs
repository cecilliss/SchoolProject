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
    public class ExamController : ApiController
    {
        private IExamService examService;
        private IMarkService markService;
        private IStudentService studentService;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        private IGradeService gradeService;
        private ISemesterService semesterService;


        public ExamController(IExamService examService, IMarkService markService, IStudentService studentService, ITeacherService teacherService,
            ISubjectService subjectService,IGradeService gradeService, ISemesterService semesterService)
        {
            this.examService = examService;
            this.markService = markService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.gradeService = gradeService;
            this.semesterService = semesterService;
        }

        [Route("school/exams")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins, teachers")]

        public IEnumerable<Exam> Get()
        {
            return examService.GetAllExams();
        }
        [Route("school/exams/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins, teachers")]
        public IHttpActionResult GetExam(int id)
        {
            Exam exam = examService.GetExam(id);

            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [Route("school/exams")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins, teachers")]
        public IHttpActionResult PostExam(Exam exam)
        {
            Exam createdExam = examService.CreateExam(exam);
            return Created("", createdExam);


        }

        [Route("school/exams/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins,teachers")]

        public IHttpActionResult PutExam(int id, Exam exam)
        {
            Exam updatedExam = examService.UpdateExam(id,exam.Name,exam.Mark,exam.Student,exam.Subject,exam.Teacher,exam.Grade,exam.Semester);

            if (updatedExam == null)
            {
                return NotFound();
            }
            return Ok(updatedExam);
        }

        [Route("school/exams/{examId:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins, teachers")]

        public IHttpActionResult DeleteExam(int examId)
        {
            Exam exam = examService.DeleteExam(examId);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        [Route("school/exams/{examId}/marks/{markId}/students/{studentId}/teachers/{teacherId}/subjects/{subjectId}/grades/{gradeId}/semesters/{semesterId}")]
        [BasicAuthentication]
        [Authorize(Roles = "admins, teachers")]
        [HttpPut]
        public IHttpActionResult PutAddsStudentTeacherSubjectGradeSemesterMarksToExams(int examId,int studentId, int markId, int teacherId, int subjectId, int gradeId, int semesterId)
        {
            Exam exam = examService.GetExam(examId);
            if (exam == null)
            {
                return NotFound();
            }

            Student student = studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }

            Mark mark = markService.GetMark(markId);
            if (mark == null)
            {
                return NotFound();
            }

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

            Grade grade = gradeService.GetGrade(gradeId);
            if (grade == null)
            {
                return NotFound();
            }

            Semester semester = semesterService.GetSemester(semesterId);
            if (semester == null)
            {
                return NotFound();
            }

            exam.Mark = mark;
            exam.Student = student;
            exam.Teacher = teacher;
            exam.Subject = subject;
            exam.Grade = grade;
            exam.Semester = semester;


            examService.UpdateExam(examId, exam.Name,exam.Mark,exam.Student,exam.Subject,exam.Teacher,exam.Grade,exam.Semester);
            studentService.SendEmail(studentId, subjectId, mark,grade,semester,teacher,examId);
            return Ok(exam);
        }

        [Route("school/exams/findByStudent/{studentId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "students, parents, admins")]

        public IEnumerable<Exam> GetExamsByStudent(int studentId)
        {
            return studentService.GetExamsByStudent(studentId);
        }




    }
}
