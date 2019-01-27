using eGradebook.Models.UserModels.UserDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class SchoolClassDTO
    {
        public int Id { get; set; }

        public Grade Grade { get; set; }

        //for example: "A", "B", "C", etc.
        public string Section { get; set; }

        public virtual SchoolYearDTO SchoolYear { get; set; }

        [JsonIgnore]
        public virtual ICollection<StudentDTO> Students { get; set; }

        [JsonIgnore]
        public virtual ICollection<TeacherTeachesCourseDTO> Courses { get; set; }
    }
}