using eGradebook.Models.UserModels.UserDTOs;
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
        public IHttpActionResult GetParentProfileById(string id)
        {
            logger.Info("Parent requesting to see own profile");

            //authentification for parent
            
            bool isParent = RequestContext.Principal.IsInRole("parent");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string parentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (parentId != id)
            {
                logger.Warn("Unauthorized access");
                return Unauthorized();
            }
            

            var parent = parentService.GetByID(id);
            if (parent == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(parent);
        }

        [Route("children/{parentId}")]
        [Authorize(Roles = "parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetChildren(string parentId)
        {
            logger.Info("Parent requesting to see a list of his children attending the school");
            var students = studentService.GetWithParentData();
            var children = new List<StudentDTO>();
            foreach (StudentDTO student in students)
            {
                if (student.Parent.Id == parentId)
                {
                    children.Add(student);
                }
            }
            if (children == null)
            {
                return NotFound();
            }
            return Ok(children);
        }


        //parent/get a child's grades
        [Route("grades/{studentId}")]
        [Authorize(Roles = "parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentCoursesAndMarks(string studentId)
        {
            logger.Info("Parent requesting to see a student's grades");

            var student = studentService.GetByID(studentId);

            //authentification for parent
            
            bool isParent = RequestContext.Principal.IsInRole("parent");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string parentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (parentId != student.Parent.Id)
            {
                logger.Warn("Unauthorized access");
                return Unauthorized();
            }
            

            var sg = sgService.GetStudentCoursesAndMarks(studentId);
            if (sg == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(sg);
        }
    }
}
