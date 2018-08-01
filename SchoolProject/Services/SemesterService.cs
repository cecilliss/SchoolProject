using SchoolProject.Models;
using SchoolProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Services
{
    public class SemesterService:ISemesterService
    {
        UnitOfWork db;

        public SemesterService(UnitOfWork db)
        {
            this.db = db;
        }

        public Semester CreateSemester(Semester semester)
        {
            db.SemesterRepository.Insert(semester);
            db.Save();
            return (semester);
        }

        public Semester DeleteSemester(int id)
        {
            Semester semester=db.SemesterRepository.GetByID(id);

            if (semester != null)
            {
                db.StudentRepository.Delete(id);
                db.Save();
            }
            return (semester);
        }

        public IEnumerable<Semester> GetAllSemesters()
        {
            return db.SemesterRepository.Get();
        }

        public Semester GetSemester(int id)
        {
            return db.SemesterRepository.GetByID(id);
        }

        public Semester UpdateSemester(int id, SEMESTER name)
        {
            Semester semester = db.SemesterRepository.GetByID(id);

            if (semester != null)
            {
                semester.Name = name;

                db.SemesterRepository.Update(semester);
                db.Save();


            }
            return (semester);
        }
    }
}