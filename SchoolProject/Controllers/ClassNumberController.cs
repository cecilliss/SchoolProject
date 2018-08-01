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
    public class ClassNumberController : ApiController
    {
        private IClassNumberService classNumberService;
        private ITeacherService teacherService;

        public ClassNumberController(IClassNumberService classNumberService, ITeacherService teacherService)
        {
            this.classNumberService = classNumberService;
            this.teacherService = teacherService;
        }

        [Route("school/classNumbers")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<ClassNumber> Get()
        {
            return classNumberService.GetAllClassNumbers();
        }

        [Route("school/classNumbers/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetClassNumber(int id)
        {
            ClassNumber classNumber = classNumberService.GetClassNumber(id);

            if (classNumber == null)
            {
                return NotFound();
            }
            return Ok(classNumber);
        }

        [Route("school/classNumbers")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostClassNumber(ClassNumber classNumber)
        {
            ClassNumber createdClassNumber = classNumberService.CreateClassNumber(classNumber);
            return Created("", createdClassNumber);
        }

        [Route("school/classNumbers/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutClassNumber(int id, ClassNumber classNumber)
        {
            ClassNumber updatedClassNumber = classNumberService.UpdateClassNumber(id,classNumber.ClassName);
            if (updatedClassNumber == null)
            {
                return NotFound();
            }
            return Ok(updatedClassNumber);
        }

        [Route("school/classNumbers/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteClassNumber(int id)
        {
            ClassNumber classNumber = classNumberService.DeleteClassNumber(id);
            if (classNumber == null)
            {
                return NotFound();
            }
            return Ok(classNumber);
        }

        [Route("school/classNumbers/findByTeacher/{teacherId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<ClassNumber> GetClassNumberByTeacher(int teacherId)
        {
            return teacherService.GetClassesByTeacher(teacherId);
        }

    }
}
