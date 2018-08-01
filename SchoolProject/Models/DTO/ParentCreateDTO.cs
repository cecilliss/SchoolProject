using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models.DTO
{
    public class ParentCreateDTO:UserCreateDTO
    {

        
        [Required]
        public string PhoneNumber { get; set; }

       
        [Required]
        public string Email { get; set; }

        
        [Required]
        public string Address { get; set; }

        public ParentCreateDTO() { }

        public ParentCreateDTO(string firstName, string lastName,string username, string password,string repeatedPassword,string phoneNumber,string email,string address)
            :base(firstName,lastName,username,password,repeatedPassword)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;

        }
    }
}