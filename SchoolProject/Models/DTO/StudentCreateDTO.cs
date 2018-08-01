using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models.DTO
{
    public class StudentCreateDTO:UserCreateDTO
    {
        
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
       
        [Required]
        public int YearOfEnrollement { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        
        public GENDER Gender { get; set; }


        public StudentCreateDTO() { }

        public StudentCreateDTO(string firstName, string lastName, string username, string password, string repeatedPassword,DateTime dateOfBirth,int yearOfEnrollement, GENDER gender)
            :base(firstName, lastName, username, password, repeatedPassword)
        {
            DateOfBirth = dateOfBirth;
            YearOfEnrollement = yearOfEnrollement;
            Gender = gender;

        }

    }
}