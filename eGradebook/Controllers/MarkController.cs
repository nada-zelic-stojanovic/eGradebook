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
    
    [RoutePrefix("api/marks")]
    public class MarkController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IMarkService markService;
        public MarkController(IMarkService markService)
        {
            this.markService = markService;
        }

        //get
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Admin requesting list of marks given");
            return Ok(markService.Get());
        }

        //getbyid
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Admin requesting a mark's details");

            MarkDTO mark = markService.GetByID(id);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        //put
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, MarkDTO markUpdate)
        {
            logger.Info("Admin updating a mark's details");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MarkDTO mark = markService.Update(id, markUpdate);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        //post
        [Route("")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(MarkDTO newMark)
        {
            logger.Info("Admin creating a new mark");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MarkDTO mark = markService.Create(newMark);
            return Ok(mark);
        }

        //delete
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info("Admin deleting a mark");

            MarkDTO mark = markService.GetByID(id);
            if (mark == null)
            {
                return NotFound();
            }
            markService.Delete(mark.Id);
            return Ok();
        }
    }
    
}
