using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("Parents")]
    public class Parent:User
    {
        [Column("Phone_Number")]
        [JsonProperty(Order =5)]
        public string PhoneNumber { get; set; }
        [Column("Email")]
        [JsonProperty(Order =6)]
        public string Email { get; set; }
        [Column("Address")]
        [JsonProperty(Order =7)]
        public string Address { get; set; }

        public Parent()
        {
            Students = new List<Student>();
        }

        public Parent(int id, string firstName, string lastName, string username, string password,
            string phoneNumber,string email,string address):base(id, firstName, lastName, username, password)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
        
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}