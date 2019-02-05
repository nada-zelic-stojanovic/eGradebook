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
    [RoutePrefix("api/gradebook/parent")]
    public class ParentGradebookController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IStudentGradebookService sgService;
        private IStudentService studentService;
        private IParentService parentService;
        public ParentGradebookController(IStudentGradebookService sgService, IParentService parentService, IStudentService studentService)
        {
            this.sgService = sgService;
            this.studentService = studentService;
            this.parentService = parentService;
        }

        //get own profile
        [Route("profile/{id}")]
        //[Authorize(Roles = "parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Parent requesting own profile info");

            var parent = parentService.GetByID(id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }


        //parent/get a child's grades
        [Route("grades/{studentId}")]
        //[Authorize(Roles = "parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentGrades(string studentId)
        {
            logger.Info("Parent requesting to see his/her child's grades");

            var sg = sgService.GetStudentGradebook(studentId);
            if (sg == null)
            {
                return NotFound();
            }
            return Ok(sg);
        }
    }
}
