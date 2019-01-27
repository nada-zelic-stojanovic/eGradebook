using eGradebook.Models.UserModels.UserDTOs;
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
            logger.Info("Requesting teachers info");
            return Ok(teacherService.Get());
        }

        [Route("{id}")]
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Requesting teacher info by id");
            return Ok(teacherService.GetByID(id));
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, TeacherDTO teacherDTO)
        {
            logger.Info("Updating teacher");

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
            logger.Info("Deleting teacher");

            TeacherDTO teacher = teacherService.GetByID(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacherService.Delete(teacher.Id);
            return Ok(teacher);
        }
    }
}
