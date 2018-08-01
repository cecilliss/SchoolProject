using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("Teachers")]
    public class Teacher:User
    {
        [JsonProperty(Order =5)]
        [Column("Qualifications")]
        public string Qualifications { get; set; }
        [JsonProperty(Order =6)]
        [Column("Years_of_Experience")]
        public int YearsOfExperience { get; set; }
        [JsonProperty(Order =7)]
        [Column("Email")]
        public string Email { get; set; }


        public Teacher(int id, string firstName, string lastName, string username, string password,
            string qualifications, int yearsOfExperience, string email):base(id, firstName, lastName, username, password)
        {
            Qualifications = qualifications;
            YearsOfExperience = yearsOfExperience;
            Email = email;
        }

        public Teacher()
        {
            Exams = new List<Exam>();
            Subjects = new List<Subject>();
            ClassNumbers = new List<ClassNumber>();
        }

        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        [JsonIgnore]
        public virtual ICollection<Subject> Subjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClassNumber> ClassNumbers { get; set; }

    }
}