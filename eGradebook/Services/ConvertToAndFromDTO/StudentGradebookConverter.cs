using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class StudentGradebookConverter
    {
        public static StudentGradebookDTO StudentTakesCourseToStudentGradebookDTO(Student student)
        {
            StudentGradebookDTO sgDTO = new StudentGradebookDTO();
            sgDTO.studentId = student.Id;
            sgDTO.StudentLastName = student.LastName;
            sgDTO.StudentFirstName = student.FirstName;
            sgDTO.CoursesAndMarks = student.StudentTakesCourses.Select(m => StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseBasicDTO(m));
            return sgDTO;
        }
    }
}