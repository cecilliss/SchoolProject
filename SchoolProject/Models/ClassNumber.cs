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
    public enum CLASS_NAME { ONE,TWO,THREE}
    [Table("Class_Numbers")]
    public class ClassNumber
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("Class_Name")]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CLASS_NAME ClassName { get; set; }

        public ClassNumber(int id,CLASS_NAME className)
        {
            Id = id;
            ClassName = className;

        }

        public ClassNumber()
        {
            Teachers = new List<Teacher>();
            Students = new List<Student>();
            Grades = new List<Grade>();
        }

        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }

    }
}