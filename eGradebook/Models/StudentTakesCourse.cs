using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models
{
    public class StudentTakesCourse
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual TeacherTeachesCourse Course { get; set; }
        public virtual ICollection<Mark> StudentsMarksFromCourse { get; set; }

        public StudentTakesCourse()
        {
            StudentsMarksFromCourse = new List<Mark>();
        }
    }
}