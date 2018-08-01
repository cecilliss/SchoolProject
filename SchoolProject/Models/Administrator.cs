using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("Administrators")]
    public class Administrator:User
    {
        [Column("Country")]
        [JsonProperty(Order =5)]
        public string Country { get; set; }
        [Column("City")]
        [JsonProperty(Order =6)]
        public string City { get; set; }

        public Administrator() { }

        public Administrator(int id, string firstName, string lastName, string username, string password, string country,string city) : base(id,firstName,lastName,username,password)
        {
            Country = country;
            City = city;
        }
    }
}