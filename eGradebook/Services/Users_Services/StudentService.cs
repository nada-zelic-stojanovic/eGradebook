using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO.Convet_Users;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.Users_Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork db;
        private IStudentConverter converter;
        private IParentService parentService;

        public StudentService(IUnitOfWork db, IStudentConverter converter, IParentService parentService)
        {
            this.db = db;
            this.converter = converter;
            this.parentService = parentService;
        }

        public IEnumerable<StudentDTO> Get()
        {
            var students = db.StudentsRepository.Get();
            if (students == null)
            {
                return null;
            }
            var studentDTOs = new List<StudentDTO>();
            foreach (Student student in students)
            {
                studentDTOs.Add(converter.StudentToStudentDTO(student));
            }
            return studentDTOs;
        }

        public StudentDTO GetByID(string id)
        {
            Student student = db.StudentsRepository.GetByID(id);
            if (student == null)
            {
                return null;
            }
            return converter.StudentToStudentDTO(student);
        }

        public StudentDTO Update(string id, StudentDTO studentDTO)
        {
            Student student = db.StudentsRepository.GetByID(id);
            converter.UpdateStudentWithStudentDTO(student, studentDTO);
            db.StudentsRepository.Update(student);
            db.Save();
            return converter.StudentToStudentDTO(student);
        }

        public StudentDTO Delete(string id)
        {
            Student student = db.StudentsRepository.GetByID(id);
            db.StudentsRepository.Delete(student);
            db.Save();
            return converter.StudentToStudentDTO(student);
        }

        public StudentDTO AddParentToStudent(string studentId, string parentId)
        {
            Student student = db.StudentsRepository.GetByID(studentId);
            Parent parent = db.ParentsRepository.GetByID(parentId);
            student.Parent = parent;
            db.StudentsRepository.Update(student);
            db.Save();
            return converter.StudentToStudentDTO(student);
        }
    }
}