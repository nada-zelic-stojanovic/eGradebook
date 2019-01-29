using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class TeacherTeachesCourse
    {
        public int Id { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Subject Subject { get; set; }

        public TeacherTeachesCourse() { }
    }
}