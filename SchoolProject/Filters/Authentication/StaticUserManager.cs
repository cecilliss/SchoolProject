using SchoolProject.Infrastructure;
using SchoolProject.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace SchoolProject.Filters.Authentication
{
    public class StaticUserManager
    {

        public static IPrincipal AuthenticateUser(string user, string pass)
        {
            IUnitOfWork db = (IUnitOfWork)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUnitOfWork));
            {
                var foundUser = db.UserRepository.Get(x => x.Username == user).FirstOrDefault();
                if (foundUser != null && foundUser.Password == CryptoHelper.CreatePassowrdHash(pass,
                foundUser.Salt))
                {
                    return new StaticUser(user, new string[] { foundUser?.Role.Name });
                }
                return null;
            }
        }
    }
}