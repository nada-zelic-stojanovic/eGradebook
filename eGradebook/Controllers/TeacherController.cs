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
    //teacher controller for admins
    [RoutePrefix("api/teachers")]
    public class TeacherController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting a list of all teachers in school");
            var teachers = teacherService.Get();
            if (teachers == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(teachers);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Admin requesting a teacher's profile");

            var teacher = teacherService.GetByID(id);
            if (teacher == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(teacher);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, TeacherDTO teacherDTO)
        {
            logger.Info("Admin updating a teacher's profile");

            if (!ModelState.IsValid)
            {
                logger.Error("Action failed due to invalid input");
                return BadRequest();
            }

            TeacherDTO teacherUpdated = teacherService.Update(id, teacherDTO);
            if (teacherUpdated == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(teacherUpdated);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            logger.Info("Admin deleting a teacher");

            TeacherDTO teacher = teacherService.GetByID(id);
            if (teacher == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            teacherService.Delete(teacher.Id);
            return Ok();
        }
    }
}
