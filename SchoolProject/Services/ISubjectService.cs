using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubject(int id);
        Subject CreateSubject(Subject subject);
        Subject UpdateSubject(int id, string name, int weeklyFond);
        Subject DeleteSubject(int id);

        IEnumerable<Student> GetStudentsBySubject(int subjectId);
        IEnumerable<Teacher> GetTeachersBySubject(int subjectId);
        IEnumerable<Grade> GetGradesBySubject(int subjectId);

    }
}
