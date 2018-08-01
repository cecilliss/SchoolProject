using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRole(int id);
        Role CreateRole(Role role);
        Role UpdateRole(int id, string name);
        Role DeleteRole(int id);
    }
}
