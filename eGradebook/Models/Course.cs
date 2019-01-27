using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string CourseName { get; set; }

        public Grade Grade { get; set; }

        public int ClassesPerWeek { get; set; }

        public Course() { }
    }
}