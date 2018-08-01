using SchoolProject.Filters.Authentication;
using SchoolProject.Models;
using SchoolProject.Models.DTO;
using SchoolProject.Repositories;
using SchoolProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService userService;
        private IRoleService roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        [Route("school/users")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IEnumerable<User> Get()
        {
            return userService.GetAllUsers();
        }

        [Route("school/users")]
        [BasicAuthentication]
        [HttpPost]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostUser(UserCreateDTO newUser)
        {
            User user = new User();
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Username = newUser.Username;
            user.Password = newUser.Password;

            if (newUser.RepeatedPassword != newUser.Password)
            {
                return BadRequest("RepeatedPassword must be the same as Password");
            }

            userService.CreateUser(user);
            return Created("", user);
        }

        [Route("school/users/{id:int}")]
        [BasicAuthentication]
        [HttpGet]
        [Authorize(Roles = "admins")]
        public IHttpActionResult GetUser(int id)
        {
            User user = userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [Route("school/users/{id:int}")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            User updatedUser = userService.UpdateUser(id, user.FirstName, user.LastName, user.Username, user.Password);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [Route("school/users/{id:int}")]
        [BasicAuthentication]
        [HttpDelete]
        [Authorize(Roles = "admins")]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = userService.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Route("school/users/{userId}/roles/{roleId}", Name = "AddUsersToRole")]
        [BasicAuthentication]
        [HttpPut]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PutAddsUsersToRole(int userId, int roleId)
        {
            User user = userService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            Role role = roleService.GetRole(roleId);
            if (role == null)
            {
                return NotFound();
            }

            user.Role = role;
            userService.UpdateUser(userId, user.FirstName, user.LastName, user.Username, user.Password);
            return Ok(user);
        }



    }
}
