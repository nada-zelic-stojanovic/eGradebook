using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public enum StudentMark { INSUFFICIENT = 1, BELOW_AVERAGE, AVERAGE, ABOVE_AVERAGE, EXCELLENT };
    public class Mark
    {
        public int Id { get; set; }

        //[JsonRequired]
        //public virtual StudentTakesCourse Student_Course { get; set; }

        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public StudentMark Value { get; set; }

        [JsonRequired]
        public DateTime DateAdded { get; set; }

    
        public Mark() { }
    }
}