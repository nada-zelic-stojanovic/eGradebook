using eGradebook.Services.IServices;
using eGradebook.Services.Users_IServices;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult GetStudentById(string id)
        {
            logger.Info("Student requesting own profile info");
            var student = studentService.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Route("grades/{studentId}")]
        //[Authorize(Roles = "student")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentGradebook(string studentId)
        {
            logger.Info("Student requesting own grades");
            var sg = sgService.GetStudentGradebook(studentId);
            if (sg == null)
            {
                return NotFound();
            }
            return Ok(sg);
        }
    }
}
