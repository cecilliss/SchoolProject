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
    public class GradesController : ApiController
    {
        private IGradeService gradeService;
        private ISubjectService subjectService;
        private IClassNumberService classNumberService;


        public GradesController(IGradeService gradeService, ISubjectService subjectService, IClassNumberService classNumberService)
        {
            this.gradeService = gradeService;
            this.subjectService = subjectService;
            this.classNumberService = classNumberService;
        }

        [Route("school/grades")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Grade> Get()
        {
            return gradeService.GetAllGrades();
        }

        [Route("school/grades/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetGrade(int id)
        {
            Grade grade = gradeService.GetGrade(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [Route("school/grades")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostGrade(Grade grade)
        {
            Grade createdGrade = gradeService.CreateGrade(grade);

            return Created("", createdGrade);
        }

        [Route("school/grades/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutGrade(int id, Grade grade)
        {
            Grade updatedGrade = gradeService.UpdateGrade(id, grade.Name);

            if (updatedGrade == null)
            {
                return NotFound();
            }
            return Ok(updatedGrade);
        }

        [Route("school/grades/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteGrade(int id)
        {
            Grade grade = gradeService.DeleteGrade(id);
            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [Route("school/grades/{gradeId:int}/classNumbers/{classNumberId:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]

        public IHttpActionResult PutAddsGradesToClassNumbers(int gradeId, int classNumberId)
        {
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

            gradeService.UpdateGrade(gradeId, grade.Name);
            return Ok(grade);
        }

        [Route("school/grades/findBySubject/{subjectId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Grade>GetGradesBySubject(int subjectId)
        {
            return subjectService.GetGradesBySubject(subjectId);
        }
    }
}
