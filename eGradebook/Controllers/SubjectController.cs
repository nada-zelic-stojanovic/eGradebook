using eGradebook.Models;
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
    [RoutePrefix("api/subjects")]
    public class SubjectController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ISubjectService subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting a list of all school subjects");
            var subjects = subjectService.Get();
            if (subjects == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok();
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a subject's details");

            var subject = subjectService.GetByID(id);
            if (subject == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(subject);
        }

        //put
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody] SubjectDTO subjectDTO)
        {
            logger.Info("Admin updating a subject");

            if (!ModelState.IsValid)
            {
                logger.Error("Action failed due to invalid input");
                return BadRequest(ModelState);
            }

            SubjectDTO subject = subjectService.Update(id, subjectDTO);
            if (subject == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(subject);
        }

        //post
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] SubjectDTO subjectDTO)
        {
            logger.Info("Admin creating a new subject");

            if (!ModelState.IsValid)
            {
                logger.Error("Action failed due to invalid input");
                return BadRequest(ModelState);
            }

            SubjectDTO subject = subjectService.Create(subjectDTO);
            return Ok(subject);
        }

        /*
        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Admin deleting a subject");

            SubjectDTO subject = subjectService.GetByID(id);
            if (subject == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            subjectService.Delete(subject.Id);
            return Ok();
        }
        */
    }
}
