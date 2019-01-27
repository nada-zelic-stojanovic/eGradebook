using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.ConvertToAndFromDTO.Convet_Users
{
    public interface IStudentConverter
    {
        StudentDTO StudentToStudentDTO(Student student);
        void UpdateStudentWithStudentDTO(Student student, StudentDTO studentDTO);
        Student StudentDTOToStudent(StudentDTO studentDTO);
    }
}
