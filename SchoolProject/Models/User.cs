using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("User")]
    public  class User
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("First_Name")]
        [JsonProperty(Order =1)]
        public string FirstName { get; set; }
        [Column("Last_Name")]
        [JsonProperty(Order =2)]
        public string LastName { get; set; }
        [Column("Username")]
        [JsonProperty(Order =3)]
        public string Username { get; set; }
        [Column("Password"), JsonIgnore]
        [JsonProperty(Order =4)]
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        [JsonIgnore]
        public byte[] Salt { get; set; }

        public User() { }

        public User(int id,string firstName,string lastName,string username,string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}