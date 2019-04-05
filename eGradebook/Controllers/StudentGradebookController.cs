using eGradebook.Services.IServices;
using eGradebook.Services.Users_IServices;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace eGradebook.Controllers
{
    [RoutePrefix("api/gradebook/student")]
    public class StudentGradebookController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IStudentGradebookService sgService;
        private IStudentService studentService;
        public StudentGradebookController(IStudentGradebookService sgService, IStudentService studentService)
        {
            this.sgService = sgService;
            this.studentService = studentService;
        }

        [Route("profile/{id}")]
        //[Authorize(Roles = "student")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentProfileById(string id)
        {
            logger.Info("Student requesting own profile info");

            //auth for student
            
            bool isStudent = RequestContext.Principal.IsInRole("student");
            bool isAuthenticatedStudent = RequestContext.Principal.Identity.IsAuthenticated;
            string studentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (studentId != id)
            {
                logger.Error("Unauthorized access");
                return Unauthorized();
            }
            

            var student = studentService.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Route("grades/{id}")]
        //[Authorize(Roles = "student")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentCoursesAndMarks(string id)
        {
            logger.Info("Student requesting own grades");

            //auth for student
            
            bool isStudent = RequestContext.Principal.IsInRole("student");
            bool isAuthenticatedStudent = RequestContext.Principal.Identity.IsAuthenticated;
            string studentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (studentId != id)
            {
                logger.Error("Unauthorized access");
                return Unauthorized();
            }
            

            var sg = sgService.GetStudentCoursesAndMarks(id);
            if (sg == null)
            {
                return NotFound();
            }
            return Ok(sg);
        }
    }
}
