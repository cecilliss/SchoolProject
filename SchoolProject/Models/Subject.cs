using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("Name")]
        [Required]
        public string Name { get; set; }
        [Column("Weekly_Fond")]
        public int WeeklyFond { get; set; }

        public Subject()
        {
            Grades = new List<Grade>();
            Exams = new List<Exam>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        public Subject(int id,string name,int weeklyFond)
        {
            Id = id;
            Name = name;
            WeeklyFond = weeklyFond;
        }

        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}