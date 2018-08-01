using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IParentService
    {
        IEnumerable<Parent> GetAllParents();
        Parent GetParent(int id);
        Parent CreateParent(Parent parent);
        Parent UpdateParent(int id, string firstName, string lastName, string username, string password,
            string phoneNumber, string email, string address);
        Parent DeleteParent(int id);

        IEnumerable<Student> GetStudentsByParent(int parentId);
    }
}
