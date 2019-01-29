using eGradebook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eGradebook.Models.UserModels;

namespace eGradebook.Infrastructure
{
    public class eGradebookContext : IdentityDbContext<IdentityUser>
    {
        public eGradebookContext() : base("eGradebookContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<eGradebookContext>());
            Database.SetInitializer(new InitializeWithDefaultData());

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<TeacherTeachesCourse> TeacherTeachesCourse { get; set; }
        public DbSet<StudentTakesCourse> StudentTakesCourse { get; set; }

        //Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Parent>().ToTable("Parent");
            modelBuilder.Entity<SchoolYear>().ToTable("SchoolYear");
            modelBuilder.Entity<Mark>().ToTable("Mark");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<SchoolClass>().ToTable("SchoolClass");
            modelBuilder.Entity<TeacherTeachesCourse>().ToTable("Teacher_Teaches_Course");
            modelBuilder.Entity<StudentTakesCourse>().ToTable("Student_Takes_Courses");
        }
    }
}