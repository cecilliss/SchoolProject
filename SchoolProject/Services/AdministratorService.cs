using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Infrastructure;
using SchoolProject.Models;
using SchoolProject.Repositories;

namespace SchoolProject.Services
{
    public class AdministratorService : IAdministratorService
    {
        IUnitOfWork db;

        public AdministratorService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Administrator CreateAdministrator(Administrator administrator)
        {
            var salt1 = CryptoHelper.GenerateRandomSalt();
            administrator.Password = CryptoHelper.CreatePassowrdHash(administrator.Password, salt1);
            administrator.Salt = salt1;
            db.AdministratorRepository.Insert(administrator);
            db.Save();

            return (administrator);
        }

        public Administrator DeleteAdministrator(int id)
        {
            Administrator administrator=db.AdministratorRepository.GetByID(id);

            if (administrator != null)
            {
                db.AdministratorRepository.Delete(id);
                db.Save();

            }
            return (administrator);
        }

        public Administrator GetAdministrator(int id)
        {
            return db.AdministratorRepository.GetByID(id);
        }

        public IEnumerable<Administrator> GetAllAdministrators()
        {
            return db.AdministratorRepository.Get();
        }

        public Administrator UpdateAdministrator(int id, string firstName, string lastName, string username, string password, string country, string city)
        {
            Administrator administrator=db.AdministratorRepository.GetByID(id);
            var salt1 = CryptoHelper.GenerateRandomSalt();

            if (administrator != null)
            {
                administrator.FirstName = firstName;
                administrator.LastName = lastName;
                administrator.Username = username;
                administrator.Password = CryptoHelper.CreatePassowrdHash(password, salt1);
                administrator.Country = country;
                administrator.City = city;

                db.AdministratorRepository.Update(administrator);
                db.Save();
            }
            return (administrator);
        }
    }
}