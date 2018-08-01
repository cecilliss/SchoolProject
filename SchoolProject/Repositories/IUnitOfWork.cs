using SchoolProject.Models;
using SchoolProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Administrator> AdministratorRepository { get; }
        IGenericRepository<Grade> GradeRepository { get; }
        IGenericRepository<Mark> MarkRepository { get; }
        IGenericRepository<Parent> ParentRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<Teacher> TeacherRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Semester> SemesterRepository { get; }
        IGenericRepository<ClassNumber> ClassNumberRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<Exam> ExamRepository { get; }
        
        
        

        void Dispose();
        void Save();

    }
}
