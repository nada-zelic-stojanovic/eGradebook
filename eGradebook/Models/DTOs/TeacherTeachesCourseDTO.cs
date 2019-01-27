using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class TeacherTeachesCourseDTO
    {
        public int Id { get; set; }

        public virtual TeacherDTO Teacher { get; set; }

        public virtual CourseDTO Course { get; set; }
    }
}