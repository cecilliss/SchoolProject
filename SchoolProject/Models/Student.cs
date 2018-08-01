using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public enum GENDER { MALE,FEMALE}

    [Table("Students")]
    public class Student:User
    {
        [JsonProperty(Order =5)]
        [Column("Date_of_Birth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty(Order =6)]
        [Column("Year_of_Enrollement")]
        public int YearOfEnrollement { get; set; }
        [JsonProperty(Order =7)]
        [JsonConverter(typeof(StringEnumConverter))]
        [Column("Gender")]
        public GENDER Gender { get; set; }


        public Student()
        {
            Parents = new List<Parent>();
            Subjects = new List<Subject>();
            Exams = new List<Exam>();
            
        }

        public Student(int id, string firstName, string lastName, string username, string password,
            DateTime dateOfBirth,int yearOfEnrollement,GENDER gender):base(id, firstName, lastName, username, password)
        {
            DateOfBirth = dateOfBirth;
            YearOfEnrollement = yearOfEnrollement;
            Gender = gender;
        }

       
        [Column("Grade_ID")]
        public virtual Grade Grade { get; set; }
        [Column("Class_ID")]
        public virtual ClassNumber ClassNumber { get; set; }

        [JsonIgnore]
        public virtual ICollection<Subject> Subjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        [JsonIgnore]
        public virtual ICollection<Parent> Parents { get; set; }


    }
}