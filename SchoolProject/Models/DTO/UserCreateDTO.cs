using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models.DTO
{
    public class UserCreateDTO
    {

        [StringLength(20,MinimumLength =2, ErrorMessage ="First name must be between 2 and 20 characters long")]
        
        [Required]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters long")]
        
        [Required]
        public string LastName { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters long")]
        
        [Required]
        public string Username { get; set; }
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 15 characters long")]
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "RepeatedPassword must be the same as Password")]
        public string RepeatedPassword { get; set; }

        public UserCreateDTO() { }

        public UserCreateDTO(string firstName,string lastName, string username, string password, string repeatedPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            RepeatedPassword = repeatedPassword;
        }
    }
}