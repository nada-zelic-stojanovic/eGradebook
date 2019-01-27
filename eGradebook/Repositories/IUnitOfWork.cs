using eGradebook.Models;
using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        
        IGenericRepository<User> UsersRepository { get; }
        IAuthRepository AuthRepository { get; }
        IGenericRepository<Student> StudentsRepository { get; }
        IGenericRepository<Parent> ParentsRepository { get; }
        IGenericRepository<Teacher> TeachersRepository { get; }
        IGenericRepository<Admin> AdminsRepository { get; }
        IGenericRepository<Mark> MarksRepository { get; }
        IGenericRepository<Course> CoursesRepository { get; }
        IGenericRepository<SchoolClass> SchoolClassesRepository { get; }
        IGenericRepository<SchoolYear> SchoolYearsRepository { get; }
        IGenericRepository<TeacherTeachesCourse> TeacherTeachesCourseRepository { get; }
        IGenericRepository<StudentTakesCourse> StudentTakesCourseRepository { get; }

        void Save();
    }
}
