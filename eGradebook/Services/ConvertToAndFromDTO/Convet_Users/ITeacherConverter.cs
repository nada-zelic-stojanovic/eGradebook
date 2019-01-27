using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.ConvertToAndFromDTO.Convet_Users
{
    public interface ITeacherConverter
    {
        TeacherDTO TeacherToTeacherDTO(Teacher teacher);
        void UpdateTeacherWithTeacherDTO(Teacher teacher, TeacherDTO teacherDTO);
    }
}
