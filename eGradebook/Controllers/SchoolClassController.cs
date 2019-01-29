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
    [RoutePrefix("api/schoolclass")]
    public class SchoolClassController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ISchoolClassService schoolClassService;
        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            this.schoolClassService = schoolClassService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Requesting school classes info");
            return Ok(schoolClassService.Get());
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Requesting a school class' info");

            var schoolClass = schoolClassService.GetById(id);
            if (schoolClass == null)
            {
                return NotFound();
            }
            return Ok(schoolClass);
        }

        //put
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, SchoolClassDTO schoolClassDTO)
        {
            logger.Info("Updating a school class");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SchoolClassDTO schoolClass = schoolClassService.Update(id, schoolClassDTO);
            if (schoolClass == null)
            {
                return NotFound();
            }
            return Ok(schoolClass);
        }

        //post
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(SchoolClassDTO schoolClassDTO)
        {
            logger.Info("Creating a new school class");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SchoolClassDTO schoolClass = schoolClassService.Create(schoolClassDTO);
            return Ok(schoolClass);
        }

        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Deleting a school class");
            SchoolClassDTO schoolClass = schoolClassService.GetById(id);
            if (schoolClass == null)
            {
                return NotFound();
            }
            schoolClassService.Delete(schoolClass.Id);
            return Ok();
        }

        [Route("{schoolClassId}/schoolYear/{schoolYearId}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutSchoolClassSchoolYear(int schoolClassId, int schoolYearId)
        {
            logger.Info("Updating School Class's School Year");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            schoolClassService.UpdateSchoolYearWithSchoolClass(schoolClassId, schoolYearId);

            return Ok();
        }
    }
}
