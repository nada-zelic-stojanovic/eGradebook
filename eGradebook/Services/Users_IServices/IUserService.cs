using eGradebook.Models.UserModels.UserDTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.Users_IServices
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAdmin(UserDTO userModel);
        Task<IdentityResult> RegisterTeacher(UserDTO userModel);
        Task<IdentityResult> RegisterStudent(UserDTO userModel);
        Task<IdentityResult> RegisterParent(ParentRegisterDTO userModel);
        Task<IdentityResult> RegisterStudentAndParent(StudentRegisterDTO studentModel, ParentRegisterDTO parentModel);
    }
}
