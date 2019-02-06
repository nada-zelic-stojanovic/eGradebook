using eGradebook.Models.DTOs;
using eGradebook.Services.IServices;
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
    [RoutePrefix("api/studentcourse")]
    public class StudentTakesCourseController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IStudentTakesCourseService studentCourseService;
        public StudentTakesCourseController(IStudentTakesCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting list of students with the courses they are taking");
            return Ok(studentCourseService.Get());
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a student's course info");

            var studentCourse = studentCourseService.GetByID(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return Ok(studentCourse);
        }

        //put
        [Route("{studentCourseId}/course/{courseId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int studentCourseId, int courseId)
        {
            logger.Info("Admin updating a student' course info");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentTakesCourseDTO studentCourse = studentCourseService.Update(studentCourseId, courseId);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return Ok(studentCourse);
        }

        //post
        [Route("student/{studentId}/course/{courseId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(string studentId, int courseId)
        {
            logger.Info("Admin creating a new student's course");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentTakesCourseDTO studentCourse = studentCourseService.Create(studentId, courseId);
            return Ok(studentCourse);
        }

        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Admin deleting a student's course");

            StudentTakesCourseDTO studentCourse = studentCourseService.GetByID(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
