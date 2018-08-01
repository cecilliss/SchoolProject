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
    public class MarksController : ApiController
    {
        private IMarkService markService;
        private IStudentService studentService;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        private IGradeService gradeService;
        private ISemesterService semesterService;
        

        public MarksController(IMarkService markService,IStudentService studentService,ITeacherService teacherService,ISubjectService subjectService,IGradeService gradeService,ISemesterService semesterService)
        {
            this.markService = markService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
            this.gradeService = gradeService;
            this.semesterService = semesterService;

            
        }

        [Route("school/marks/adminRole")]  
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles ="admins, teachers")]
        
        public IEnumerable<Mark> Get()
        {
            return markService.GetAllMarks();
        }
        [Route("school/marks/{id:int}")]       
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles ="admins, teachers")]
        public IHttpActionResult GetMark(int id)
        {
            Mark mark= markService.GetMark(id);

            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        [Route("school/marks")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles ="admins, teachers")]
        
        
        public IHttpActionResult PostMark(Mark mark)
        {
            Mark createdMark = markService.CreateMark(mark);
            return Created("", createdMark);


        }

        [Route("school/marks/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles ="admins,teachers")]
        
        public IHttpActionResult PutMark(int id, Mark mark)
        {
            Mark updatedMark = markService.UpdateMark(id, mark.MarkValue, mark.Date);

            if (updatedMark == null)
            {
                return NotFound();
            }
            return Ok(updatedMark);
        }

        [Route("school/marks/{markId:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins, teachers")]
        
        public IHttpActionResult DeleteMark(int markId)
        {
            Mark mark = markService.DeleteMark(markId);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

       



    }
}
