using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int id);
        Teacher CreateTeacher(Teacher teacher);
        Teacher UpdateTeacher(int id,string firstName,string lastName,string username, string password, string qualifications,
            int yearsOfExperience, string email);
        Teacher DeleteTeacher(int id);

        IEnumerable<Subject> GetSubjectsByTeacher(int teacherId);
        IEnumerable<ClassNumber> GetClassesByTeacher(int teacherId);
    }
}
