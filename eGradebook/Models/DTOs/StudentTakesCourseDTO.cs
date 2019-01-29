using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class StudentTakesCourseDTO
    {
        public int Id { get; set; }
        public virtual StudentDTO Student { get; set; }
        public virtual TeacherTeachesCourseDTO Course { get; set; }
        public virtual ICollection<MarkDTO> StudentsMarksFromCourse { get; set; }
    }
}