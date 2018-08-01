using SchoolProject.Models;
using SchoolProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace SchoolProject.Repositories
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private DbContext context;
        

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        [Dependency]
        public IGenericRepository<Administrator> AdministratorRepository { get; set; }
        [Dependency]
        public IGenericRepository<Grade> GradeRepository { get; set; }
        [Dependency]
        public IGenericRepository<Mark> MarkRepository { get; set; }
        [Dependency]
        public IGenericRepository<Parent> ParentRepository { get; set; }
        [Dependency]
        public IGenericRepository<Student> StudentRepository { get; set; }
        [Dependency]
        public IGenericRepository<Subject> SubjectRepository { get; set; }
        [Dependency]
        public IGenericRepository<Teacher> TeacherRepository { get; set; }
        [Dependency]
        public IGenericRepository<User> UserRepository { get; set; }
        [Dependency]
        public IGenericRepository<Semester> SemesterRepository { get; set; }
        [Dependency]
        public IGenericRepository<ClassNumber> ClassNumberRepository { get; set; }
        [Dependency]
        public IGenericRepository<Role> RoleRepository { get; set; }
        [Dependency]
        public IGenericRepository<Exam> ExamRepository { get; set; }
       

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                //if (disposing)
                //{
                //    context.Dispose();
                //}
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}