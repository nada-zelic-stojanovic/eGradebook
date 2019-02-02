using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class SchoolClassBasicDTO
    {
        public int Id { get; set; }

        public Grade Grade { get; set; }

        //for example: "A", "B", "C", etc.
        public string Section { get; set; }

        public virtual SchoolYearDTO SchoolYear { get; set; }
    }
}