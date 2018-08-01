using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models.DTO
{
    public class TeacherCreateDTO:UserCreateDTO
    {
        
        
        [Required]
        public string Qualifications { get; set; }
        
        
        public int YearsOfExperience { get; set; }
        
        
        [Required]
        public string Email { get; set; }

        public TeacherCreateDTO() { }

        public TeacherCreateDTO(string firstName, string lastName, string username, string password,string repeatedPassword,
            string qualifications, int yearsOfExperience, string email):base(firstName, lastName, username, password, repeatedPassword)
        {
            Qualifications = qualifications;
            YearsOfExperience = yearsOfExperience;
            Email = email;
        }
    }
}