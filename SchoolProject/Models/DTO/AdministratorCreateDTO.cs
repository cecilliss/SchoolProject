using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models.DTO
{
    public class AdministratorCreateDTO:UserCreateDTO
    {
        
        
        [Required]
        public string Country { get; set; }
        
        
        [Required]
        public string City { get; set; }

        public AdministratorCreateDTO() { }

        public AdministratorCreateDTO(string firstName, string lastName, string username, string password, string repeatedPassword,string country,string city) 
            : base(firstName, lastName, username, password, repeatedPassword)
        {
            Country = country;
            City = city;
        }
    }
}