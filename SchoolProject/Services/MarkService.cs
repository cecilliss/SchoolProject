using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class MarkService : IMarkService
    {
        IUnitOfWork db;

        public MarkService(IUnitOfWork db)
        {
            this.db = db;
        }
        public Mark CreateMark(Mark mark)
        {
            db.MarkRepository.Insert(mark);
            db.Save();

            return (mark);
        }

        public Mark DeleteMark(int id)
        {
            Mark mark=db.MarkRepository.GetByID(id);

            if (mark != null)
            {
                db.MarkRepository.Delete(id);
                db.Save();
            }

            return (mark);
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            return db.MarkRepository.Get();
        }

        public Mark GetMark(int id)
        {
            return db.MarkRepository.GetByID(id);
        }

        

        public Mark UpdateMark(int id, int markValue, DateTime date)
        {
            Mark mark=db.MarkRepository.GetByID(id);

            if (mark != null)
            {
                mark.MarkValue = markValue;
                mark.Date = date;
                

                db.MarkRepository.Update(mark);
                db.Save();
            }
            return (mark);
        }
    }
}