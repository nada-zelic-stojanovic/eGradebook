using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
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
        private IParentService parentService;

        public StudentService(IUnitOfWork db, IParentService parentService)
        {
            this.db = db;
            this.parentService = parentService;
        }

        public IEnumerable<StudentBasicDTO> Get()
        {
            var students = db.StudentsRepository.Get();
            if (students == null)
            {
                return null;
            }
            var studentDTOs = new List<StudentBasicDTO>();
            foreach (Student student in students)
            {
                studentDTOs.Add(StudentConverter.StudentToStudentBasicDTO(student));
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
            return StudentConverter.StudentToStudentDTO(student);
        }

        public StudentUpdateDTO Update(string id, StudentUpdateDTO studentDTO)
        {
            Student student = db.StudentsRepository.GetByID(id);
            StudentConverter.UpdateStudentWithStudentDTO(student, studentDTO);
            db.StudentsRepository.Update(student);
            db.Save();
            return StudentConverter.StudentToStudentUpdateDTO(student);
        }

        public void Delete(string id)
        {
            Student student = db.StudentsRepository.GetByID(id);
            db.StudentsRepository.Delete(student);
            db.Save();
        }

        public StudentDTO UpdateStudentWithParent(string studentId, string parentId)
        {
            Student student = db.StudentsRepository.GetByID(studentId);
            Parent parent = db.ParentsRepository.GetByID(parentId);
            student.Parent = parent;
            db.StudentsRepository.Update(student);
            db.Save();
            return StudentConverter.StudentToStudentDTO(student);
        }
    }
}