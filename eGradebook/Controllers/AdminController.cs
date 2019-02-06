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
            logger.Info("Admin requesting list of admins");
            var admins = adminService.Get();
            if (admins == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(admins);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Admin requesting an admin's profile");
            var admin = adminService.GetByID(id);
            if (admin == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            return Ok(admin);
        }

        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, AdminDTO adminDTO)
        {
            logger.Info("Admin updating an admin's profile");

            if (!ModelState.IsValid)
            {
                logger.Error("Action failed due to invalid input");
                return BadRequest();
            }
            AdminDTO adminUpdated = adminService.Update(id, adminDTO);
            if (adminUpdated == null)
            {
                logger.Error("Data not found");
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
            logger.Info("Admin deleting an admin");

            AdminDTO admin = adminService.GetByID(id);
            if (admin == null)
            {
                logger.Error("Data not found");
                return NotFound();
            }
            adminService.Delete(admin.Id);
            return Ok();
        }
    }
}
