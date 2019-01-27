using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.Users_IServices
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> Get();
        StudentDTO GetByID(string id);
        StudentDTO Update(string id, StudentDTO studentDTO);
        StudentDTO Delete(string id);

        StudentDTO AddParentToStudent(string studentId, string parentId);
    }
}
