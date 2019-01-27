using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class SchoolYear
    {
        public int Id { get; set; }
        //for example: "SchoolYear 2018/2019"
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SchoolYear() { }
    }
}