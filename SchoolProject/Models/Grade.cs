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
    

    public enum NAME { FIRST_GRADE,SECOND_GRADE,THIRD_GRADE,FOURTH_GRADE,FIFTH_GRADE,SIXTH_GRADE,SEVENTH_GRADE,EIGHTH_GRADE}
    [Table("Grades")]
    public class Grade
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("Grade")]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public NAME Name { get; set; }
        

        public Grade()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
            Semesters = new List<Semester>();
            ClassNumbers = new List<ClassNumber>();
            Exams = new List<Exam>();
            
        }

        public Grade(int id,NAME name)
        {
            Id = id;
            Name = name;
           
        }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
        [JsonIgnore]
        public virtual ICollection<Subject>Subjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Semester> Semesters { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClassNumber> ClassNumbers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
       
        
    }
}