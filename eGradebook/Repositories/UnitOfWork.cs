using eGradebook.Models;
using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using Unity.Attributes;

namespace eGradebook.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        
        [Dependency]
        public IGenericRepository<User> UsersRepository { get; set; }

        [Dependency]
        public IAuthRepository AuthRepository { get; set; }

        [Dependency]
        public IGenericRepository<Student> StudentsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Teacher> TeachersRepository { get; set; }

        [Dependency]
        public IGenericRepository<Parent> ParentsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Admin> AdminsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Mark> MarksRepository { get; set; }

        [Dependency]
        public IGenericRepository<Subject> SubjectsRepository { get; set; }

        [Dependency]
        public IGenericRepository<SchoolClass> SchoolClassesRepository { get; set; }

        [Dependency]
        public IGenericRepository<SchoolYear> SchoolYearsRepository { get; set; }

        [Dependency]
        public IGenericRepository<TeacherTeachesCourse> TeacherTeachesCourseRepository { get; set; }

        [Dependency]
        public IGenericRepository<StudentTakesCourse> StudentTakesCourseRepository { get; set; }


        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}