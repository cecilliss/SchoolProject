using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface ISemesterService
    {
        IEnumerable<Semester> GetAllSemesters();
        Semester GetSemester(int id);
        Semester CreateSemester(Semester semester);
        Semester UpdateSemester(int id, SEMESTER name);
        Semester DeleteSemester(int id);

    }
}
