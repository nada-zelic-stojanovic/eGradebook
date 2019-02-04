using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class StudentGradebookDTO
    {
        public string studentId { get; set; }

        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }

        public IEnumerable<StudentTakesCourseBasicDTO> CoursesAndMarks { get; set; }
    }
}