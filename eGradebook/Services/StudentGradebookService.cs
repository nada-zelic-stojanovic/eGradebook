using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Models.UserModels;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services
{
    public class StudentGradebookService : IStudentGradebookService
    {
        private IUnitOfWork db;

        public StudentGradebookService(IUnitOfWork db)
        {
            this.db = db;
        }

        //get own grades
        public StudentGradebookDTO GetStudentGradebook(string studentId)
        {
            Student sg = db.StudentsRepository.GetByID(studentId);
            var courses = db.StudentTakesCourseRepository.Get();
            var studentCourses = new List<StudentTakesCourse>();
            foreach (StudentTakesCourse course in courses)
            {
                if (course.Student.Id == studentId)
                {
                    studentCourses.Add(course);
                }
            }
            sg.StudentTakesCourses = studentCourses;

            return StudentGradebookConverter.StudentTakesCourseToStudentGradebookDTO(sg);
        }
    }
}