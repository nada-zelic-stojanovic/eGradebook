using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.Users_IServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eGradebook.Services.Users_Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork db;
        public UserService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<IdentityResult> RegisterAdmin(UserDTO userModel)
        {
            Admin user = new Admin
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
            return await db.AuthRepository.RegisterAdmin(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterParent(ParentRegisterDTO userModel)
        {
            Parent user = new Parent
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
            return await db.AuthRepository.RegisterParent(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterStudent(UserDTO userModel)
        {
            Student user = new Student
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
            user.SchoolClass = new Models.SchoolClass()
            {
                Grade = Models.Grade.UNSORTED,
                Section = "0",
                SchoolYear = new Models.SchoolYear()
                {
                    Name = "SchoolYear to be added",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(3000, 12, 31)
                }
            };
            return await db.AuthRepository.RegisterStudent(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterTeacher(UserDTO userModel)
        {
            Teacher user = new Teacher
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
            return await db.AuthRepository.RegisterTeacher(user, userModel.Password);
        }

        public async Task<IdentityResult> RegisterStudentAndParent(StudentRegisterDTO studentModel, ParentRegisterDTO parentModel)
        {

            Parent parent = new Parent
            {
                UserName = parentModel.UserName,
                FirstName = parentModel.FirstName,
                LastName = parentModel.LastName,
                Email = parentModel.Email
            };
            await db.AuthRepository.RegisterParent(parent, parentModel.Password);

            Student student = new Student
            {
                UserName = studentModel.UserName,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Email = studentModel.Email
            };
            student.SchoolClass = new Models.SchoolClass()
            {
                Grade = Models.Grade.UNSORTED,
                Section = "0",
                SchoolYear = new Models.SchoolYear()
                {
                    Name = "SchoolYear to be added",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(3000, 12, 31)
                }
            };
            IdentityResult result = await db.AuthRepository.RegisterStudent(student, studentModel.Password);


            student.Parent = parent;
            db.StudentsRepository.Update(student);
            db.ParentsRepository.Update(parent);
            db.Save();

            return result;
        }
    }
}