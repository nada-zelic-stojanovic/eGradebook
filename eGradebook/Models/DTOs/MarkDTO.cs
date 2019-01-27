using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class MarkDTO
    {
        public int Id { get; set; }

        [JsonRequired]
        public virtual StudentTakesCourseDTO Student_Course { get; set; }

        // [JsonRequired]
        // public virtual TeacherTeachesCourse Teacher_Course { get; set; }

        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public StudentMark Value { get; set; }

        [JsonRequired]
        public DateTime DateAdded { get; set; }
    }
}