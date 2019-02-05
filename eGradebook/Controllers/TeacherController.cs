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
            return Ok(teacherService.Get());
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("ADmin requesting a teacher's profile");

            var teacher = teacherService.GetByID(id);
            if (teacher == null)
            {
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
                return BadRequest();
            }

            TeacherDTO teacherUpdated = teacherService.Update(id, teacherDTO);
            if (teacherUpdated == null)
            {
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
                return NotFound();
            }
            teacherService.Delete(teacher.Id);
            return Ok();
        }
    }
}
