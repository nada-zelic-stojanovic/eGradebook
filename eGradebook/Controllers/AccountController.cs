using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Services.Users_IServices;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eGradebook.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "admin")]
        [Route("register/admin")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAdmin(UserDTO userModel)
        {
            logger.Info("Register admin");

            if (!ModelState.IsValid)
            {
                logger.Error("Register unsuccessful due to invalid data input.");
                return BadRequest(ModelState);
            }

            var result = await userService.RegisterAdmin(userModel);

                if (result == null)
                {
                    return BadRequest(ModelState);
                }

                return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [Route("register/teacher")]
        [HttpPost]
        public async Task<IHttpActionResult> PostTeacher(UserDTO userModel)
        {
            logger.Info("Register teacher");

            if (!ModelState.IsValid)
            {
                logger.Error("Register unsuccessful due to invalid data input.");
                return BadRequest(ModelState);
            }

            var result = await userService.RegisterTeacher(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }


        [Authorize(Roles = "admin")]
        [Route("register/studentandparent")]
        [HttpPost]
        public async Task<IHttpActionResult> PostStudentAndParent(StudentRegisterDTO studentModel)
        {
            logger.Info("Register student and parent");

            if (!ModelState.IsValid)
            {
                logger.Error("Register unsuccessful due to invalid data input.");
                return BadRequest(ModelState);
            }


            var result = await userService.RegisterStudentAndParent(studentModel, studentModel.Parent);

            if (result == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [Route("register/student")]
        [HttpPost]
        public async Task<IHttpActionResult> PostStudent(UserDTO userModel)
        {
            logger.Info("Register student");

            if (!ModelState.IsValid)
            {
                logger.Error("Register unsuccessful due to invalid data input.");
                return BadRequest(ModelState);
            }

            var result = await userService.RegisterStudent(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [Route("register/parent")]
        [HttpPost]
        public async Task<IHttpActionResult> PostParent(ParentRegisterDTO userModel)
        {
            logger.Info("Register parent");

            if (!ModelState.IsValid)
            {
                logger.Error("Register unsuccessful due to invalid data input.");
                return BadRequest(ModelState);
            }

            var result = await userService.RegisterParent(userModel);

            if (result == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
