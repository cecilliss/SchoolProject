using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork db;

        public RoleService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Role CreateRole(Role role)
        {
            db.RoleRepository.Insert(role);
            db.Save();

            return (role);
        }

        public Role DeleteRole(int id)
        {
            Role role = db.RoleRepository.GetByID(id);

            if (role != null)
            {
                db.RoleRepository.Delete(id);
                db.Save();
            }
            return (role);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return db.RoleRepository.Get();
        }

        public Role GetRole(int id)
        {
            return db.RoleRepository.GetByID(id);
        }

        public Role UpdateRole(int id, string name)
        {
            Role role = db.RoleRepository.GetByID(id);

            if (role != null)
            {
                role.Name = name;


                db.RoleRepository.Update(role);
                db.Save();
            }
            return (role);
        }
    }
}