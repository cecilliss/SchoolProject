using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IClassNumberService
    {
        IEnumerable<ClassNumber> GetAllClassNumbers();
        ClassNumber GetClassNumber(int id);
        ClassNumber CreateClassNumber(ClassNumber classNumber);
        ClassNumber UpdateClassNumber(int id, CLASS_NAME className);
        ClassNumber DeleteClassNumber(int id);

        IEnumerable<Teacher> GetTeachersByClassNumber(int classNumberid);
        IEnumerable<Grade> GetGradesByClassNumber(int classNumberId);

    }
}
