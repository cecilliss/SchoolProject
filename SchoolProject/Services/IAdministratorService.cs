using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IAdministratorService
    {
        IEnumerable<Administrator> GetAllAdministrators();
        Administrator GetAdministrator(int id);
        Administrator CreateAdministrator(Administrator administrator);
        Administrator UpdateAdministrator(int id, string firstName, string lastName, string username, string password,
            string country, string city);
        Administrator DeleteAdministrator(int id);
    }
}
