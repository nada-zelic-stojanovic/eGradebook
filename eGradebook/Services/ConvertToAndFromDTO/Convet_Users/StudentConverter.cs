using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO.Convet_Users
{
    public class StudentConverter : IStudentConverter
    {
        public IParentConverter parentConverter;

        public StudentDTO StudentToStudentDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();

            studentDTO.Id = student.Id;
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.UserName = student.UserName;
            studentDTO.Email = student.Email;
            //studentDTO.Parent = parentConverter.ParentToParentDTO(student.Parent);
            //studentDTO.SchoolClass = student.SchoolClass;

            return studentDTO;
        }

        public void UpdateStudentWithStudentDTO(Student student, StudentDTO studentDTO)
        {
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.UserName = studentDTO.UserName;
            student.Email = studentDTO.Email;
           // student.Parent = parentConverter.ParentDTOToParent(studentDTO.Parent);
            //student.SchoolClass = studentDTO.SchoolClass;
        }

        public Student StudentDTOToStudent(StudentDTO studentDTO)
        {
            Student student = new Student();

            student.Id = studentDTO.Id;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.UserName = studentDTO.UserName;
            student.Email = studentDTO.Email;
            //student.Parent = parentConverter.ParentDTOToParent(studentDTO.Parent);
            //student.SchoolClass = studentDTO.SchoolClass;

            return student;
        }
    }
}