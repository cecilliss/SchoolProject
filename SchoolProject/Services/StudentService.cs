using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using SchoolProject.Infrastructure;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class StudentService : IStudentService
    {
        IUnitOfWork db;

        public StudentService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Student CreateStudent(Student student)
        {
            var salt3 = CryptoHelper.GenerateRandomSalt();
            student.Password = CryptoHelper.CreatePassowrdHash(student.Password, salt3);
            student.Salt = salt3;
            db.StudentRepository.Insert(student);
            db.Save();
            return (student);
        }

        public Student DeleteStudent(int id)
        {
            Student student=db.StudentRepository.GetByID(id);

            if (student != null)
            {
                db.StudentRepository.Delete(id);
                db.Save();
            }
            return (student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.StudentRepository.Get();
        }

        public IEnumerable<Exam> GetExamsByStudent(int studentId)
        {

            Student student = db.StudentRepository.GetByID(studentId);
            List<Exam> exams = new List<Exam>();

            foreach (Exam exam in student.Exams)
            {
                exams.Add(exam);
            }
            return (exams);
        }


       



        public IEnumerable<Parent> GetParentsByStudent(int studentId)
        {
            Student student=db.StudentRepository.GetByID(studentId);
            List<Parent> parents = new List<Parent>();

            foreach(Parent parent in student.Parents)
            {
                parents.Add(parent);
            }

            return (parents);

        }

        public Student GetStudent(int id)
        {
            return db.StudentRepository.GetByID(id);
        }

       

        public IEnumerable<Subject> GetSubjectsByStudent(int studentId)
        {
            Student student = db.StudentRepository.GetByID(studentId);
            List<Subject> subjects = new List<Subject>();

            foreach (Subject subject in student.Subjects)
            {
                subjects.Add(subject);
            }
            return (subjects);
        }

        public void SendEmail(int studentId, int subjectId, Mark mark, Grade grade, Semester semester, Teacher teacher, int examId)
        {
            Student student = db.StudentRepository.GetByID(studentId);

            if (student.Parents.Count() > 0)
            {
                Subject subject1 = db.SubjectRepository.GetByID(subjectId);

                string subject= String.Format($"Ucenik {student.FirstName} {student.LastName} je dobio novu ocenu!");

                string body = String.Format($"Postovani roditelji,\n ucenik/ca {student.FirstName} {student.LastName} je dana{mark.Date} dobio/la ocenu {mark.MarkValue} iz predmeta {subject1.Name} od profesora {teacher.FirstName} {teacher.LastName}");

                string FromMail = ConfigurationManager.AppSettings["from"];
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);
                mail.From = new MailAddress(FromMail);

                foreach(Parent parent in student.Parents)
                {
                    mail.To.Add(parent.Email);
                }

                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["password"]);
                SmtpServer.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["smtpSsl"]);
                SmtpServer.Send(mail);

            }
        }

        public Student UpdateStudent(int id, string firstName, string lastName, string username, string password, DateTime dateOfBirth, int yearOfEnrollement, GENDER gender)
        {
            Student student=db.StudentRepository.GetByID(id);
            var salt3 = CryptoHelper.GenerateRandomSalt();

            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Username = username;
                student.Password = CryptoHelper.CreatePassowrdHash(password, salt3);
                student.DateOfBirth = dateOfBirth;
                student.YearOfEnrollement = yearOfEnrollement;
                student.Gender = gender;

                db.StudentRepository.Update(student);
                db.Save();
            }

            return (student);
        }
    }
}