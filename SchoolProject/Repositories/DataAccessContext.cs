using SchoolProject.Models;
using SchoolProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolProject.Repositories
{
    public class DataAccessContext:DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new
            InitializeWithDefaultUsers());
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<ClassNumber> ClassNumbers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Exam> Exams { get; set; }
        

    }
}