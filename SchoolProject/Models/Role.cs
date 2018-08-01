using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
        
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}