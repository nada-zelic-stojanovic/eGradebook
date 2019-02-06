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
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting list of all students");
            var students = studentService.Get();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Admin requesting to see a student profile");
            StudentDTO studentDTO = studentService.GetByID(id);
            if (studentDTO == null)
            {
                return NotFound();
            }

            return Ok(studentDTO); 
        }


        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, StudentUpdateDTO studentDTO)
        {
            logger.Info("Admin updating a student's profile");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            StudentUpdateDTO studentUpdated = studentService.Update(id, studentDTO);
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
            logger.Info("Admin deleting a student");

            StudentDTO student = studentService.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            studentService.Delete(id);
            //parentService.Delete(student.Parent.Id);
            return Ok();
        }


        [Route("{studentId}/parent/{parentId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutStudentParent(string studentId, string parentId)
        {
            logger.Info("Admin updating a Student's Parent");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            studentService.UpdateStudentWithParent(studentId, parentId);

            return Ok();
        }

        [Route("{studentId}/schoolClass/{schoolClassId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutStudentToSchoolClass(string studentId, int schoolClassId)
        {
            logger.Info("Admin updating a student's school-class details");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            studentService.UpdateStudentSchoolClass(studentId, schoolClassId);
            return Ok();
        }
    }
}
