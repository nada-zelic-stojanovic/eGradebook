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
        IEnumerable<StudentBasicDTO> Get();
        StudentDTO GetByID(string id);
        StudentUpdateDTO Update(string id, StudentUpdateDTO studentDTO);
        void Delete(string id);

        StudentDTO UpdateStudentWithParent(string studentId, string parentId);
    }
}
