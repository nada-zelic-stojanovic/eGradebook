using eGradebook.Models.UserModels;
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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IAdminService adminService;
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Requesting admins info");
            return Ok(adminService.Get());
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Requesting admin info by id");
            return Ok(adminService.GetByID(id));
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, AdminDTO adminDTO)
        {
            logger.Info("Updating admin");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            AdminDTO adminUpdated = adminService.Update(id, adminDTO);
            if (adminUpdated == null)
            {
                return NotFound();
            }
            return Ok(adminUpdated);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            logger.Info("Deleting admin");

            AdminDTO admin = adminService.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }
            adminService.Delete(admin.Id);
            return Ok(admin);
        }
    }
}
