using SchoolProject.Models;
using SchoolProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Services
{
    public class ExamService:IExamService
    {
        IUnitOfWork db;

        public ExamService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Exam CreateExam(Exam exam)
        {
            db.ExamRepository.Insert(exam);
            db.Save();

            return (exam);

        }

        public Exam DeleteExam(int id)
        {
            Exam exam = db.ExamRepository.GetByID(id);

            if (exam != null)
            {
                db.ExamRepository.Delete(id);
                db.Save();
            }

            return (exam);
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return db.ExamRepository.Get();
        }

        public Exam GetExam(int id)
        {
            return db.ExamRepository.GetByID(id);
        }

        public Exam UpdateExam(int id, string name,Mark mark, Student student, Subject subject, Teacher teacher, Grade grade, Semester semester)
        {
            Exam exam = db.ExamRepository.GetByID(id);

            if (exam != null)
            {
                exam.Name = name;
                exam.Mark = mark;
                exam.Student = student;
                exam.Subject = subject;
                exam.Teacher = teacher;
                exam.Grade = grade;
                exam.Semester = semester;


                db.ExamRepository.Update(exam);
                db.Save();
            }
            return (exam);
        }
    }
}