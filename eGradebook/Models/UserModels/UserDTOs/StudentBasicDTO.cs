using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.UserModels.UserDTOs
{
    public class StudentBasicDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SchoolClassBasicDTO SchoolClass { get; set; }
    }
}