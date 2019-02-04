using eGradebook.Infrastructure;
using eGradebook.Models;
using eGradebook.Models.UserModels;
using eGradebook.Providers;
using eGradebook.Repositories;
using eGradebook.Services;
using eGradebook.Services.IServices;
using eGradebook.Services.Users_IServices;
using eGradebook.Services.Users_Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

//states which class to fire on start-up
[assembly: OwinStartup(typeof(eGradebook.Startup))]
namespace eGradebook
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SetupUnity();
            ConfigureOAuth(app, container);

            //HttpConfiguration object is used to configure API routes
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            WebApiConfig.Register(config);
            //UseWebApi --> will be responsible to wire up ASP.NEt Web API to our Owin server pipeline
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, UnityContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(100),
                Provider = new SimpleAuthorizationServerProvider(container)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private UnityContainer SetupUnity()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, eGradebookContext>(new HierarchicalLifetimeManager());
            
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IAuthRepository, AuthRepository>();
            container.RegisterType<IGenericRepository<Student>, GenericRepository<Student>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Admin>, GenericRepository<Admin>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Mark>, GenericRepository<Mark>>();
            container.RegisterType<IGenericRepository<SchoolYear>, GenericRepository<SchoolYear>>();
            container.RegisterType<IGenericRepository<SchoolClass>, GenericRepository<SchoolClass>>();
            container.RegisterType<IGenericRepository<TeacherTeachesCourse>, GenericRepository<TeacherTeachesCourse>>();
            container.RegisterType<IGenericRepository<StudentTakesCourse>, GenericRepository<StudentTakesCourse>>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IParentService, ParentService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IMarkService, MarkService>();
            container.RegisterType<ISchoolYearService, SchoolYearService>();
            container.RegisterType<ISchoolClassService, SchoolClassService>();
            container.RegisterType<ITeacherTeachesCourseService, TeacherTeachesCourseService>();
            container.RegisterType<IStudentTakesCourseService, StudentTakesCourseService>();

            container.RegisterType<ITeacherGradebookService, TeacherGradebookService>();
            container.RegisterType<IStudentGradebookService, StudentGradebookService>();

            return container;
        }
    }
}