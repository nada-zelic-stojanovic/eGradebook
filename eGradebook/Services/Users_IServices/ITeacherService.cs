using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.Users_IServices
{
    public interface ITeacherService
    {
        IEnumerable<TeacherDTO> Get();
        TeacherDTO GetByID(string id);
        TeacherDTO Update(string id, TeacherDTO teacherDTO);
        TeacherDTO Delete(string id);
    }
}
