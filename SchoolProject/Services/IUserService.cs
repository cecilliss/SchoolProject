using SchoolProject.Models;
using SchoolProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(int id, string firstName, string lastName, string username, string password);
        User DeleteUser(int id);
    }   
}
