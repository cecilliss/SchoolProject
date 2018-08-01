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
    public enum SEMESTER { FIRST, SECOND }

    [Table("Semesters")]
    public class Semester
    {
        [JsonProperty("ID") ]
        public int Id { get; set; }
        [Column("Semester")]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public SEMESTER Name { get; set; }

        public Semester(int id,SEMESTER name)
        {
            Id = id;
            Name = name;
        }

        public Semester()
        {
            Exams = new List<Exam>();
            Grades = new List<Grade>();


        }

        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }






    }
}