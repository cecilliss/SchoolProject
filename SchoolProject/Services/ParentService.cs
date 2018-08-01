using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Infrastructure;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class ParentService : IParentService
    {
        IUnitOfWork db;

        public ParentService(IUnitOfWork db)
        {
            this.db = db;
        }
        public Parent CreateParent(Parent parent)
        {
            var salt2 = CryptoHelper.GenerateRandomSalt();
            parent.Password = CryptoHelper.CreatePassowrdHash(parent.Password, salt2);
            parent.Salt = salt2;

            db.ParentRepository.Insert(parent);
            db.Save();
            return (parent);
        }

        public Parent DeleteParent(int id)
        {
            Parent parent=db.ParentRepository.GetByID(id);

            if (parent != null)
            {
                db.ParentRepository.Delete(id);
                db.Save();
            }
            return (parent);
        }

        public IEnumerable<Parent> GetAllParents()
        {
            return db.ParentRepository.Get();
        }

        public Parent GetParent(int id)
        {
            return db.ParentRepository.GetByID(id);
        }

        public IEnumerable<Student> GetStudentsByParent(int parentId)
        {
            Parent parent=db.ParentRepository.GetByID(parentId);
            List<Student> students = new List<Student>();

            foreach(Student student in parent.Students)
            {
                students.Add(student);
            }
            return students;
        }

        public Parent UpdateParent(int id, string firstName, string lastName, string username, string password, string phoneNumber, string email, string address)
        {
            Parent parent=db.ParentRepository.GetByID(id);
            var salt2 = CryptoHelper.GenerateRandomSalt();






            if (parent != null)
            {
                parent.FirstName = firstName;
                parent.LastName = lastName;
                parent.Username = username;
                parent.Password = CryptoHelper.CreatePassowrdHash(password, salt2);
                parent.PhoneNumber = phoneNumber;
                parent.Email = email;
                parent.Address = address;


                

                db.ParentRepository.Update(parent);
                db.Save();
            }
           
            return (parent);
        }
    }
}