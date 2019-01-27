using eGradebook.Models.UserModels.UserDTOs;
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
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IStudentService studentService;
        private IParentService parentService;
        public StudentController(IStudentService studentService, IParentService parentService)
        {
            this.studentService = studentService;
            this.parentService = parentService;
        }

        //DTOs
        [Route("")]
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Requesting students info");
            return Ok(studentService.Get());
        }

        [Route("{id}")]
        [Authorize(Roles = "admin, teacher, student, parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Requesting student info by id");
            StudentDTO studentDTO = studentService.GetByID(id);
            if (studentDTO == null)
            {
                return NotFound();
            }
            //authentification for parent
            bool isParent = RequestContext.Principal.IsInRole("parent");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string parentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (parentId != studentDTO.Parent.Id)
            {
                return Unauthorized();
            }

            //auth for student
            bool isStudent = RequestContext.Principal.IsInRole("student");
            bool isAuthenticatedStudent = RequestContext.Principal.Identity.IsAuthenticated;
            string studentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (studentId != id)
            {
                return Unauthorized();
            }

            return Ok(studentDTO);
        }


        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, StudentDTO studentDTO)
        {
            logger.Info("Updating student");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            StudentDTO studentUpdated = studentService.Update(id, studentDTO);
            if (studentUpdated == null)
            {
                return NotFound();
            }
            return Ok(studentUpdated);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            logger.Info("Deleting student");

            StudentDTO student = studentService.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            studentService.Delete(id);
            return Ok(student);
        }


        [Route("{studentId}/parent/{parentId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutStudentParent(string studentId, string parentId)
        {
            logger.Info("Adding a parent to a student");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            studentService.AddParentToStudent(studentId, parentId);

            return Ok();
        }
    }
}
