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
    [RoutePrefix("api/parents")]
    public class ParentController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IParentService parentService;
        public ParentController(IParentService parentService)
        {
            this.parentService = parentService;
        }

      
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting list of all parents");
            var parents = parentService.Get();
            if (parents == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(parents);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Admin requesting to see a parent's profile");

            var parent = parentService.GetByID(id);
            if (parent == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(parent);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, ParentUpdateDTO parentDTO)
        {
            logger.Info("Admin updating a parent's profile");

            if (!ModelState.IsValid)
            {
                logger.Error("Update failed due to invalid input");
                return BadRequest();
            }
            ParentUpdateDTO parentUpdated = parentService.Update(id, parentDTO);
            if (parentUpdated == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(parentUpdated);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            logger.Info("Admin deleting a parent");

            ParentDTO parent = parentService.GetByID(id);
            if (parent == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            parentService.Delete(id);
            return Ok();
        }
    }
}
