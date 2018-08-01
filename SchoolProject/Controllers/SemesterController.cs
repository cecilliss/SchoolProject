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
    public class SemesterController : ApiController
    {
        private ISemesterService semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        [Route("school/semesters")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Semester> Get()
        {
            return semesterService.GetAllSemesters();
        }

        [Route("school/semesters/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetSemester(int id)
        {
            Semester semester = semesterService.GetSemester(id);

            if (semester == null)
            {
                return NotFound();
            }
            return Ok(semester);
        }

        [Route("school/semesters")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostSemester(Semester semester)
        {
            Semester createdSemester = semesterService.CreateSemester(semester);
            return Created("", createdSemester);

        }

        [Route("school/semesters/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutSemester(int id, Semester semester)
        {
            Semester updatedSemester = semesterService.GetSemester(id);
            if (updatedSemester == null)
            {
                NotFound();
            }
            return Ok(updatedSemester);
        }

        [Route("school/semesters/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteSemester(int id)
        {
            Semester semester = semesterService.DeleteSemester(id);

            if (semester == null)
            {
                return NotFound();
            }
            return Ok(semester);
        }

            

    }
}
