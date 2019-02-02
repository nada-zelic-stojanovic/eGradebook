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
        //[Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Requesting marks info");
            return Ok(markService.Get());
        }

        //getbyid
        [Route("{id}")]
        //[Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            logger.Info("Requesting a mark's info");

            MarkDTO mark = markService.GetByID(id);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        //put
        [Route("{id}")]
        //[Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, MarkDTO markUpdate)
        {
            logger.Info("Updating a mark");

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
        //[Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(MarkDTO newMark)
        {
            logger.Info("Creating a new mark");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MarkDTO mark = markService.Create(newMark);
            return Ok(mark);
        }

        //delete
        [Route("{id}")]
        //[Authorize(Roles = "admin, teacher")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult DeleteMark(int id)
        {
            logger.Info("Deleting a mark");

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
