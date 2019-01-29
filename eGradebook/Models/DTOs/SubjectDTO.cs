using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }

        public int ClassesPerWeek { get; set; }
    }
}