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
    [RoutePrefix("api/schoolyear")]
    public class SchoolYearController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ISchoolYearService schoolYearService;
        public SchoolYearController(ISchoolYearService schoolYearService)
        {
            this.schoolYearService = schoolYearService;
        }

        //get
        [Route("")]
       // [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetSchoolYears()
        {
            logger.Info("Admin requesting list of school years");
            var schoolYears = schoolYearService.Get();
            if (schoolYears == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolYears);
        }

        //get by id
        [Route("{id}")]
       // [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a school year's details");

            var schoolYear = schoolYearService.GetById(id);
            if (schoolYear == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolYear);
        }

        //put
        [Route("{id}")]
       // [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, SchoolYearDTO schoolYearDTO)
        {
            logger.Info("Admin updating a school year's details");

            if (!ModelState.IsValid)
            {
                logger.Error("Update failed due to invalid input");
                return BadRequest(ModelState);
            }
            SchoolYearDTO schoolYear = schoolYearService.Update(id, schoolYearDTO);
            if (schoolYear == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(schoolYear);
        }

        //post
        [Route("")]
       // [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(SchoolYearDTO schoolYearDTO)
        {
            logger.Info("Admin creating a new school year");
            if (!ModelState.IsValid)
            {
                logger.Error("Action failed due to invalid input");
                return BadRequest(ModelState);
            }
            SchoolYearDTO schoolYear = schoolYearService.Create(schoolYearDTO);
            return Ok(schoolYear);
        }

        //delete
        [Route("{id}")]
       // [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Warn("Admin deleting a school year");
            SchoolYearDTO schoolYear = schoolYearService.GetById(id);
            if (schoolYear == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            schoolYearService.Delete(schoolYear.Id);
            return Ok();
        }
    }
}
