using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetAllGrades();
        Grade GetGrade(int id);
        Grade CreateGrade(Grade grade);
        Grade UpdateGrade(int id, NAME name);
        Grade DeleteGrade(int id);

        IEnumerable<Subject> GetSubjectsByGrade(int gradeId);
        IEnumerable<ClassNumber> GetClassNumbersByGrade(int gradeId);
        IEnumerable<Student> GetStudentsByGradeAndClassNumber(int gradeId, int classNumberId);
    }
}
