using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class StudentTakesCourseBasicDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }

        public IEnumerable<MarkDTO> Marks { get; set; }
    }
}