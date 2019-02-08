using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace eGradebook.Controllers
{
    [RoutePrefix("api/logs")]
    public class LoggingController : ApiController
    {
        [Route("{date}")]
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetLog(string date)
        {
            StreamReader log = null;
            string path = @"D:\cSharp\myProjects\eGradebook\eGradebook\logs\" + date + ".log";

            string text = "";

            try
            {
                log = new StreamReader(path);
                while (true)
                {
                    string line = log.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    text = text + line + Environment.NewLine;
                }
                return Ok(text);
            }
            catch (IOException e)
            {
                return NotFound();
            }
            finally
            {
                if (log == null)
                {
                    log.Close();
                }
            }

        }
    }
}
