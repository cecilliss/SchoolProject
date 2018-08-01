using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    [Table("Exams")]
    public class Exam
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("Exam_Name")]
        public string Name { get; set; }

        public Exam() { }

        public Exam(int id, string name, Mark mark, Semester semester, Grade grade, Teacher teacher, Student student, Subject subject)
        {
            Id = id;
            Name = name;
            Mark = mark;
            Semester = semester;
            Grade = grade;
            Teacher = teacher;
            Student = student;
            Subject = subject;
        }
        




        [Column("Mark_ID")]
        public virtual Mark Mark { get; set; }
        [Column("Semester_ID")]
        public virtual Semester Semester { get; set; }
        [Column("Teacher_ID")]
        public virtual Teacher Teacher { get; set; }
        [Column("Student_ID")]
        public virtual Student Student { get; set; }
        [Column("Subject_ID")]
        public virtual Subject Subject { get; set; }
        [Column("Grade_ID")]
        public virtual Grade Grade { get; set; }


    }
}