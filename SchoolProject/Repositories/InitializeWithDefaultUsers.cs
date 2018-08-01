using SchoolProject.Infrastructure;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolProject.Repositories
{
    public class InitializeWithDefaultUsers: DropCreateDatabaseIfModelChanges<DataAccessContext>
    {
        protected override void Seed(DataAccessContext context)
        {
            Role adminRole = new Role() { Name = "admins" };
            adminRole = context.Roles.Add(adminRole);

            Role studentRole = new Role() { Name = "students" };
            studentRole = context.Roles.Add(studentRole);

            Role teacherRole = new Role() { Name = "teachers" };
            teacherRole = context.Roles.Add(teacherRole);

            Role parentRole = new Role() { Name = "parents" };
            parentRole = context.Roles.Add(parentRole);


            var salt1 = CryptoHelper.GenerateRandomSalt();
            User u1 = new User();
            u1.FirstName = "Ivan";
            u1.LastName = "Vasiljevic";
            u1.Username = "ivanv";
            u1.Password = CryptoHelper.CreatePassowrdHash("ivan88", salt1);
            u1.Role = adminRole;
            u1.Salt = salt1;
            u1 = context.Users.Add(u1);

            var salt2 = CryptoHelper.GenerateRandomSalt();
            User u2 = new User();
            u2.FirstName = "Mladen";
            u2.LastName = "Kanostrevac";
            u2.Username = "mladenk";
            u2.Password = CryptoHelper.CreatePassowrdHash("mladja123", salt2);
            u2.Role = adminRole;
            u2.Salt = salt2;
            u2 = context.Users.Add(u2);

            var salt3 = CryptoHelper.GenerateRandomSalt();
            User u3 = new User();
            u3.FirstName = "Nikola";
            u3.LastName = "Mitrovic";
            u3.Username = "nikolam";
            u3.Password = CryptoHelper.CreatePassowrdHash("nidza12", salt3);
            u3.Role = studentRole;
            u3.Salt = salt3;
            u3 = context.Users.Add(u3);

            var salt4 = CryptoHelper.GenerateRandomSalt();
            User u4 = new User();
            u4.FirstName = "Milica";
            u4.LastName = "Utrzan";
            u4.Username = "micaki";
            u4.Password = CryptoHelper.CreatePassowrdHash("milicau", salt4);
            u4.Role = studentRole;
            u4.Salt = salt4;
            u4 = context.Users.Add(u4);

            var salt5 = CryptoHelper.GenerateRandomSalt();
            User u5 = new User();
            u5.FirstName = "Nadezda";
            u5.LastName = "Vlajkov";
            u5.Username = "nadjav";
            u5.Password = CryptoHelper.CreatePassowrdHash("vlajkovn", salt5);
            u5.Role = studentRole;
            u5.Salt = salt5;
            u5 = context.Users.Add(u5);

            var salt6 = CryptoHelper.GenerateRandomSalt();
            User u6 = new User();
            u6.FirstName = "Biljana";
            u6.LastName = "Repasic";
            u6.Username = "biljare";
            u6.Password = CryptoHelper.CreatePassowrdHash("bilja12", salt6);
            u6.Role = teacherRole;
            u6.Salt = salt6;
            u6 = context.Users.Add(u6);

            var salt7 = CryptoHelper.GenerateRandomSalt();
            User u7 = new User();
            u7.FirstName = "Vesna";
            u7.LastName = "Kijurski";
            u7.Username = "vesnak";
            u7.Password = CryptoHelper.CreatePassowrdHash("kijav", salt7);
            u7.Role = teacherRole;
            u7.Salt = salt7;
            u7 = context.Users.Add(u7);

            var salt8 = CryptoHelper.GenerateRandomSalt();
            User u8 = new User();
            u8.FirstName = "Zlatana";
            u8.LastName = "Ljuboja";
            u8.Username = "zlata56";
            u8.Password = CryptoHelper.CreatePassowrdHash("zlataljub", salt8);
            u8.Role = parentRole;
            u8.Salt = salt8;
            u8 = context.Users.Add(u8);

            var salt9 = CryptoHelper.GenerateRandomSalt();
            User u9 = new User();
            u9.FirstName = "Dragan";
            u9.LastName = "Pavlovic";
            u9.Username = "draganp";
            u9.Password = CryptoHelper.CreatePassowrdHash("gagip", salt9);
            u9.Role = parentRole;
            u9.Salt = salt9;
            u9 = context.Users.Add(u9);

            context.SaveChanges();

        }
    }
}