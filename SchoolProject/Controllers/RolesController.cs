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
    public class RolesController : ApiController
    {
        private IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [Route("school/roles")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<Role> Get()
        {
            return roleService.GetAllRoles();
        }

        [Route("school/roles/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetRole(int id)
        {
            Role role = roleService.GetRole(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [Route("school/roles")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostRole(Role role)
        {
            Role createdRole = roleService.CreateRole(role);

            return Created("", createdRole);
        }

        [Route("school/roles/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutRole(int id, Role role)
        {
            Role updatedRole = roleService.UpdateRole(id, role.Name);

            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(updatedRole);
        }

        [Route("school/roles/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = roleService.DeleteRole(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }


    }
}
