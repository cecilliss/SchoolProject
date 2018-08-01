using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IExamService
    {
        IEnumerable<Exam> GetAllExams();
        Exam GetExam(int id);

        Exam CreateExam(Exam exam);
        Exam UpdateExam(int id,string Name,Mark mark,Student student,Subject subject,Teacher teacher, Grade grade, Semester semester);
        Exam DeleteExam(int id);

    }
}
