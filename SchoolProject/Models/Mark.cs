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
    
    [Table("Marks")]
    public class Mark
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [Column("Mark_Value")]
        [Required]
        [Range(1,5,ErrorMessage ="Value must be between 1 and 5")]
        public int MarkValue { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
       

       
       

        public Mark()
        {

            Exams = new List<Exam>();
            
           
            
        }

        public Mark(int id,int markValue,DateTime date)
        {
            Id = id;
            MarkValue = markValue;
            Date = date;
            
        }

        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }


        




    }
}