using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class SubjectService : ISubjectService
    {
        IUnitOfWork db;

        public SubjectService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Subject CreateSubject(Subject subject)
        {
            db.SubjectRepository.Insert(subject);
            db.Save();

            return (subject);
        }

        public Subject DeleteSubject(int id)
        {
            Subject subject=db.SubjectRepository.GetByID(id);

            if (subject != null)
            {
                db.SubjectRepository.Delete(id);
                db.Save();
            }
            return (subject);
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return db.SubjectRepository.Get();
        }

        public IEnumerable<Grade> GetGradesBySubject(int subjectId)
        {
            Subject subject=db.SubjectRepository.GetByID(subjectId);
            List<Grade> grades = new List<Grade>();

            foreach(Grade grade in subject.Grades)
            {
                grades.Add(grade);
            }
            return (grades);
        }

        public IEnumerable<Student> GetStudentsBySubject(int subjectId)
        {
            Subject subject = db.SubjectRepository.GetByID(subjectId);
            List<Student> students = new List<Student>();

            foreach (Student student in subject.Students)
            {
                students.Add(student);
            }

            return (students);

        }

        public Subject GetSubject(int id)
        {
            return db.SubjectRepository.GetByID(id);
        }

        public IEnumerable<Teacher> GetTeachersBySubject(int subjectId)
        {
            Subject subject=db.SubjectRepository.GetByID(subjectId);
            List<Teacher> teachers = new List<Teacher>();

            foreach(Teacher teacher in subject.Teachers)
            {
                teachers.Add(teacher);
            }
            return (teachers);
        }

        public Subject UpdateSubject(int id, string name, int weeklyFond)
        {
            Subject subject=db.SubjectRepository.GetByID(id);

            if (subject != null)
            {
                subject.Name = name;
                subject.WeeklyFond = weeklyFond;

                db.SubjectRepository.Update(subject);
                db.Save();
            }

            return (subject);
        }
    }
}