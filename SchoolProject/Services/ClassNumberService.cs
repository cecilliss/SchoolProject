using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class ClassNumberService : IClassNumberService
    {
        IUnitOfWork db;

        public ClassNumberService(IUnitOfWork db)
        {
            this.db = db;
        }

        public ClassNumber CreateClassNumber(ClassNumber classNumber)
        {
            db.ClassNumberRepository.Insert(classNumber);
            db.Save();
            return (classNumber);
        }

        public ClassNumber DeleteClassNumber(int id)
        {
            ClassNumber classNumber = db.ClassNumberRepository.GetByID(id) ;
            if (classNumber != null)
            {
                db.ClassNumberRepository.Delete(id);
                db.Save();
            }
            return (classNumber);
        }

        public IEnumerable<ClassNumber> GetAllClassNumbers()
        {
            return db.ClassNumberRepository.Get();
        }

        public ClassNumber GetClassNumber(int id)
        {
            return db.ClassNumberRepository.GetByID(id);
        }

        public IEnumerable<Grade> GetGradesByClassNumber(int classNumberId)
        {
            ClassNumber classNumber=db.ClassNumberRepository.GetByID(classNumberId);
            List<Grade> grades = new List<Grade>();

            foreach(Grade grade in classNumber.Grades)
            {
                grades.Add(grade);
            }

            return (grades);
        }

        public IEnumerable<Teacher> GetTeachersByClassNumber(int classNumberId)
        {
            ClassNumber classNumber=db.ClassNumberRepository.GetByID(classNumberId);
            List<Teacher> teachers = new List<Teacher>();

            foreach(Teacher teacher in classNumber.Teachers)
            {
                teachers.Add(teacher);
            }
            return (teachers);
        }

        public ClassNumber UpdateClassNumber(int id, CLASS_NAME className)
        {
            ClassNumber classNumber = db.ClassNumberRepository.GetByID(id);
            if (classNumber != null)
            {
                classNumber.ClassName = className;

                db.ClassNumberRepository.Update(classNumber);
                db.Save();
            }

            return (classNumber);
        }
    }
}