using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace eGradebook.Models.UserModels
{
    public class Student : User
    {

        public virtual Parent Parent { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentTakesCourse> StudentTakesCourses { get; set; }

        //constructor
        public Student()
        {
            StudentTakesCourses = new List<StudentTakesCourse>();
        }

        public override async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}