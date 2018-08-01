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
    public class AdministratorsController : ApiController
    {
        private IAdministratorService administratorService;

        public AdministratorsController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }

        [Route("school/administrators")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Administrator> Get()
        {
            return administratorService.GetAllAdministrators();
        }

        [Route("school/administrators/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetAdministrator(int id)
        {
            Administrator administrator= administratorService.GetAdministrator(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        [Route("school/administrators")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostAdministrator(AdministratorCreateDTO newAdministrator)
        {
            Administrator administrator = new Administrator();
            administrator.FirstName = newAdministrator.FirstName;
            administrator.LastName = newAdministrator.LastName;
            administrator.Username = newAdministrator.Username;
            administrator.Password = newAdministrator.Password;
            administrator.Country = newAdministrator.Country;
            administrator.City = newAdministrator.City;

            if (newAdministrator.RepeatedPassword != newAdministrator.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }

            Administrator createdAdministrator = administratorService.CreateAdministrator(administrator);

            return Created("", createdAdministrator);
        }

        [Route("school/administrators/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutAdministrator(int id,AdministratorCreateDTO administrator)
        {
            Administrator updatedAdministrator = administratorService.UpdateAdministrator(id, administrator.FirstName, administrator.LastName, administrator.Username, administrator.Password,
                administrator.Country, administrator.City);

            if (updatedAdministrator == null)
            {
                return NotFound();
            }
            if (administrator.RepeatedPassword != administrator.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }
            return Ok(updatedAdministrator);
        }

        [Route("school/administrators/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteAdministrator(int id)
        {
            Administrator administrator = administratorService.DeleteAdministrator(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }
    }
}
