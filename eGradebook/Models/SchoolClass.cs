using eGradebook.Models.UserModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }

        public Grade Grade { get; set; }

        //for example: "A", "B", "C", etc.
        public string Section { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

        [JsonIgnore]
        public virtual ICollection<TeacherTeachesCourse> Courses { get; set; }

        public SchoolClass()
        {
            Students = new List<Student>();
            Courses = new List<TeacherTeachesCourse>();
        }
    }
}