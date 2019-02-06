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
    [RoutePrefix("api/courses")]
    public class TeacherTeachesCourseController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ITeacherTeachesCourseService courseService;
        public TeacherTeachesCourseController(ITeacherTeachesCourseService courseService)
        {
            this.courseService = courseService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting a list of all courses");
            return Ok(courseService.Get());
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a course's details");

            var course = courseService.GetByID(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        //put -- change teacher
        [Route("{id}/teacher/{teacherId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, string teacherId)
        {
            logger.Info("Admin updating a course");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TeacherTeachesCourseDTO course = courseService.Update(id, teacherId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        //post - from existing teacher and subject
        [Route("teacher/{teacherId}/subject/{subjectId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(string teacherId, int subjectId)
        {
            logger.Info("Admin creating a new course with existing teacher and subject");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TeacherTeachesCourseDTO courseDTO = courseService.Create(teacherId, subjectId);

            return Ok(courseDTO);
        }


        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Admin deleting a course");

            TeacherTeachesCourseDTO course = courseService.GetByID(id);
            if (course == null)
            {
                return NotFound();
            }
            courseService.Delete(course.Id);
            return Ok();
        }
    }
}
