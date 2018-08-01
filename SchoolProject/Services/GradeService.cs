using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class GradeService : IGradeService
    {
        IUnitOfWork db;

        public GradeService(IUnitOfWork db)
        {
            this.db = db;
        }
        public Grade CreateGrade(Grade grade)
        {
            db.GradeRepository.Insert(grade);
            db.Save();
            return (grade);
        }

        public Grade DeleteGrade(int id)
        {
            Grade grade=db.GradeRepository.GetByID(id);

            if (grade != null)
            {
                db.GradeRepository.Delete(id);
                db.Save();
            }
            return (grade);
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return db.GradeRepository.Get();
        }

        public IEnumerable<ClassNumber> GetClassNumbersByGrade(int gradeId)
        {
            Grade grade = db.GradeRepository.GetByID(gradeId);
            List<ClassNumber> classes = new List<ClassNumber>();

            foreach(ClassNumber classNumber in grade.ClassNumbers)
            {
                classes.Add(classNumber);
            }
            return (classes);
        }

        public Grade GetGrade(int id)
        {
            return db.GradeRepository.GetByID(id);
        }

        public IEnumerable<Student> GetStudentsByGradeAndClassNumber(int gradeId, int classNumberId)
        {
            Grade grade=db.GradeRepository.GetByID(gradeId);
            ClassNumber classNumber = db.ClassNumberRepository.GetByID(classNumberId);
            List<Student> students = new List<Student>();

            foreach(Student student in grade.Students)
            {
                students.Add(student);
            }

            foreach(Student student in classNumber.Students)
            {
                students.Add(student);                       
            }

            

            return (students);
        }

        public IEnumerable<Subject> GetSubjectsByGrade(int gradeId)
        {
            Grade grade=db.GradeRepository.GetByID(gradeId);
            List<Subject> subjects = new List<Subject>();

            foreach(Subject subject in grade.Subjects)
            {
                subjects.Add(subject);
            }
            return (subjects);
        }

        public Grade UpdateGrade(int id, NAME name)
        {
            Grade grade=db.GradeRepository.GetByID(id);

            if (grade != null)
            {
                grade.Name = name;
                

                db.GradeRepository.Update(grade);
                db.Save();
            }
            return (grade);
        }
    }
}