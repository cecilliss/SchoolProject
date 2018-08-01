using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Infrastructure;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class TeacherService : ITeacherService
    {
        IUnitOfWork db;

        public TeacherService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Teacher CreateTeacher(Teacher teacher)
        {
            var salt4 = CryptoHelper.GenerateRandomSalt();
            teacher.Password = CryptoHelper.CreatePassowrdHash(teacher.Password, salt4);
            teacher.Salt = salt4;

            db.TeacherRepository.Insert(teacher);
            db.Save();
            return (teacher); 
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.TeacherRepository.Get();
        }

        public Teacher GetTeacher(int id)
        {
            return db.TeacherRepository.GetByID(id);
        }

        public Teacher UpdateTeacher(int id,string firstName,string lastName,string username,string password,string qualifications,int yearsofExperience,string email)
        {
            Teacher teacher = db.TeacherRepository.GetByID(id);
            var salt4 = CryptoHelper.GenerateRandomSalt();


            if (teacher != null)
            {
                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.Username = username;
                teacher.Password = CryptoHelper.CreatePassowrdHash(password, salt4);
                teacher.Qualifications=qualifications;
                teacher.YearsOfExperience = yearsofExperience;
                teacher.Email = email;

                db.TeacherRepository.Update(teacher);
                db.Save();
            }

            return (teacher);



        }

        public Teacher DeleteTeacher(int id)
        {
            Teacher teacher = db.TeacherRepository.GetByID(id);

            if (teacher != null)
            {
                db.TeacherRepository.Delete(id);
                db.Save();
            }
            return (teacher);
        }

        public IEnumerable<Subject> GetSubjectsByTeacher(int teacherId)
        {
            Teacher teacher=db.TeacherRepository.GetByID(teacherId);
            List<Subject> subjects = new List<Subject>();

            foreach(Subject subject in teacher.Subjects)
            {
                subjects.Add(subject);
            }
            return (subjects);
        }

        public IEnumerable<ClassNumber> GetClassesByTeacher(int teacherId)
        {
            Teacher teacher=db.TeacherRepository.GetByID(teacherId);
            List<ClassNumber> classes = new List<ClassNumber>();

            foreach(ClassNumber classNumber in teacher.ClassNumbers)
            {
                classes.Add(classNumber);
            }

            return (classes);
        }
    }
}