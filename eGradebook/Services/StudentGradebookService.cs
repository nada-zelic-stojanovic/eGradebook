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

            return StudentGradebookConverter.StudentTakesCourseToStudentGradebookDTO(sg);
        }
    }
}