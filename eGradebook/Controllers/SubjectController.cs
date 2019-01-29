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
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Requesting subjects info");
            return Ok(subjectService.Get());
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Requesting a subject's info");

            var subject = subjectService.GetByID(id);
            if (subject == null)
            {
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
            logger.Info("Updating a subject");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubjectDTO subject = subjectService.Update(id, subjectDTO);
            if (subject == null)
            {
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
            logger.Info("Creating a new subject");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubjectDTO subject = subjectService.Create(subjectDTO);
            return Ok(subject);
        }

        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Deleting a subject");

            SubjectDTO subject = subjectService.GetByID(id);
            if (subject == null)
            {
                return NotFound();
            }
            subjectService.Delete(subject.Id);
            return Ok();
        }
    }
}
