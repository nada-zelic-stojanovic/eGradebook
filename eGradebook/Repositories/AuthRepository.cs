using eGradebook.Models.UserModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eGradebook.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private UserManager<User> _userManager;

        public AuthRepository(DbContext context)
        {
            _userManager = new UserManager<User>(new UserStore<User>(context));

        }

        //register users
        public async Task<IdentityResult> RegisterAdmin(Admin admin, string password)
        {
            var result = await _userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(admin.Id, "admin");
            }
            return result;
        }

        public async Task<IdentityResult> RegisterParent(Parent parent, string password)
        {
            var result = await _userManager.CreateAsync(parent, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(parent.Id, "parent");
            }
            return result;
        }

        public async Task<IdentityResult> RegisterStudent(Student student, string password)
        {
            var result = await _userManager.CreateAsync(student, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(student.Id, "student");
            }
            return result;
        }

        public async Task<IdentityResult> RegisterTeacher(Teacher teacher, string password)
        {
            var result = await _userManager.CreateAsync(teacher, password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(teacher.Id, "teacher");
            }
            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IList<string>> FindRoles(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
        }
    }
}