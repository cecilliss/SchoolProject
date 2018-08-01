using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(int id, string firstName, string lastName, string username, string password,
            DateTime dateOfBirth, int yearOfEnrollement, GENDER gender);
        Student DeleteStudent(int id);

        IEnumerable<Parent> GetParentsByStudent(int studentId);
        IEnumerable<Subject> GetSubjectsByStudent(int studentId);
        IEnumerable<Exam> GetExamsByStudent(int studentId);

        

        void SendEmail(int studentId, int subjectId, Mark mark, Grade grade, Semester semester, Teacher teacher, int examId);

        


    }
}
