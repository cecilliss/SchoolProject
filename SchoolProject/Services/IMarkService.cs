using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IMarkService
    {
        IEnumerable<Mark> GetAllMarks();
        Mark GetMark(int id);
        
        Mark CreateMark(Mark mark);
        Mark UpdateMark(int id, int markValue, DateTime date );
        Mark DeleteMark(int id);


    }
}
