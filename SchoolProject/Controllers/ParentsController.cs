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
    public class ParentsController : ApiController
    {
        private IParentService parentService;
        private IStudentService studentService;

        public ParentsController(IParentService parentService,IStudentService studentService)
        {
            this.parentService = parentService;
            this.studentService = studentService;
        }

        [Route("school/parents")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Parent> Get()
        {
            return parentService.GetAllParents();
        }

        [Route("school/parents/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetParent(int id)
        {
            Parent parent = parentService.GetParent(id);

            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

        [Route("school/parents")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostParent(ParentCreateDTO newParent)
        {
            Parent parent = new Parent();
            parent.FirstName = newParent.FirstName;
            parent.LastName = newParent.LastName;
            parent.Username = newParent.Username;
            parent.Password = newParent.Password;
            parent.PhoneNumber = newParent.PhoneNumber;
            parent.Email = newParent.Email;
            parent.Address = newParent.Address;

            if (newParent.RepeatedPassword != newParent.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }


            Parent createdParent = parentService.CreateParent(parent);
            return Created("", createdParent);
        }

        [Route("school/parents/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutParent(int id,ParentCreateDTO parent)
        {
           

            Parent updatedParent = parentService.UpdateParent(id, parent.FirstName, parent.LastName, parent.Username, parent.Password,
                parent.PhoneNumber, parent.Email, parent.Address);


            if (updatedParent == null)
            {
                return NotFound();
            }
            if (parent.RepeatedPassword != parent.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }

            return Ok(updatedParent);

        }

        [Route("school/parents/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteParent(int id)
        {
            Parent parent = parentService.DeleteParent(id);

            if (parent == null)
            {
                return NotFound();
            }

            return Ok(parent);
        }

        [Route("school/parents/{parentId}/students/{studentId}", Name ="AddParentsToStudents")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutParentToStudent(int parentId,int studentId)
        {
            Parent parent = parentService.GetParent(parentId);
            if (parent == null)
            {
                return NotFound();
            }

            Student student = studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }



            parent.Students.Add(student);
            student.Parents.Add(parent);

            parentService.UpdateParent( parent.Id, parent.FirstName, parent.LastName, parent.Username, parent.Password,parent.PhoneNumber, parent.Email, parent.Address);
            

            return Ok(parent);
        }

        [Route("school/parents/findByStudent/{studentId:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Parent>GetParentsByStudent(int studentId)
        {
            return studentService.GetParentsByStudent(studentId);
        }



    }
}
