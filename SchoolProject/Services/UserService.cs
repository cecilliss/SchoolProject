using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Infrastructure;
using SchoolProject.Models;
using SchoolProject.Models.DTO;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork db;
        public UserService(IUnitOfWork db)
        {
            this.db = db;
        }

        public User CreateUser(User user)
        {
           

            db.UserRepository.Insert(user);
            db.Save();
            return (user); ;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.UserRepository.Get();
        }

        public User GetUser(int id)
        {
            return db.UserRepository.GetByID(id);
        }

        public User UpdateUser(int id,string firstName,string lastName,string username, string password)
        {
            User user = db.UserRepository.GetByID(id);
            

            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Username = username;
                user.Password = password;

                db.UserRepository.Update(user);
                db.Save();
            }
            return (user);
        }

        public User DeleteUser(int id)
        {
            User user = db.UserRepository.GetByID(id);
            if (user != null)
            {
                db.UserRepository.Delete(id);
                db.Save();
            }

            return (user);
        }
    }
}