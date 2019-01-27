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
            logger.Info("Requesting parents info");
            return Ok(parentService.Get());
        }

        [Route("{id}")]
        [Authorize(Roles = "admin, parent")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Requesting student info by id");

            //authentification for parent
            bool isParent = RequestContext.Principal.IsInRole("parent");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string parentId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (parentId != id)
            {
                return Unauthorized();
            }

            return Ok(parentService.GetByID(id));
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, ParentDTO parentDTO)
        {
            logger.Info("Updating parent");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ParentDTO parentUpdated = parentService.Update(id, parentDTO);
            if (parentUpdated == null)
            {
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
            logger.Info("Deleting parent");

            ParentDTO parent = parentService.GetByID(id);
            if (parent == null)
            {
                return NotFound();
            }
            parentService.Delete(id);
            return Ok(parent);
        }
    }
}
