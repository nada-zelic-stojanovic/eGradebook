﻿using eGradebook.Models.DTOs;
using eGradebook.Services.IServices;
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
    [RoutePrefix("api/gradebook/teacher")]
    public class TeacherGradebookController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ITeacherGradebookService teacherGradebookService;

        private ITeacherService teacherService;
        //private IStudentService studentService;

        private IMarkService markService;
        private ITeacherTeachesCourseService courseService;
        private IStudentTakesCourseService studentCourseService;
        private ISchoolClassService schoolClassService;

        public TeacherGradebookController(ITeacherGradebookService teacherGradebookService, IMarkService markService, ITeacherTeachesCourseService courseService, IStudentTakesCourseService studentCourseService, ISchoolClassService schoolClassService, ITeacherService teacherService)
        {
            this.markService = markService;
            this.courseService = courseService;
            this.studentCourseService = studentCourseService;
            this.schoolClassService = schoolClassService;
            this.teacherService = teacherService;
            this.teacherGradebookService = teacherGradebookService;
        }

        //teacher: get own profile info
        [Route("profile/{id}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            logger.Info("Teacher requesting own profile info");
            
            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }
            
            var teacher = teacherService.GetByID(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        //teacher: get SchoolClasses that he/she teaches
        [Route("{id}/schoolclasses")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            logger.Info("Teacher requesting list of schoolclasses that he/she teaches");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            return Ok(teacherGradebookService.GetTeacherTeachingClasses(teacherId));
        }

        //teacher: get a school class that he/she teaches by class id
        [Route("{id}/schoolClasses/{schoolClassId}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetById(string id, int schoolClassId)
        {
            logger.Info("Teacher requesting a school class' info");
            
            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }
            
            var schoolClass = schoolClassService.GetById(schoolClassId);
            if (schoolClass == null)
            {
                return NotFound();
            }
            return Ok(schoolClass);
        }

        //get courses taught by certain teacher
        [Route("{id}/courses")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetTeacherCourses(string id)
        {
            logger.Info("Teacher requesting a lis of courses he/she teaches");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            return Ok(teacherGradebookService.GetTeacherTeachingCourses(id));
        }

        //teacher: get student marks 
        [Route("{id}/student/{studentId}/course/{courseId}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpGet]
        public IHttpActionResult GetStudentsMarksFromCourse(string id, string studentId, int courseId)
        {
            logger.Info("Teacher requesting list of a student's marks from a course");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            var studentMarks = teacherGradebookService.GetStudentsMarksFromCourse(studentId, courseId);
            return Ok(studentMarks);
        }

        //create a student's mark
        [Route("{id}/student/{studentId}/course/{courseId}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PostStudentMark(string id, string studentId, int courseId, MarkDTO markDTO)
        {
            logger.Info("Teacher giving student a mark");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = teacherGradebookService.GiveStudentAMark(studentId, courseId, markDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //put/ update a mark
        [Route("{id}/mark/{markId}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(string id, int markId, MarkDTO markUpdate)
        {
            logger.Info("Teacher updating a mark");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MarkDTO mark = markService.Update(markId, markUpdate);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        //teacher deletes a mark
        [Route("{id}/mark/{markid}")]
        [Authorize(Roles = "teacher")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult DeleteMark(string id, int markId)
        {
            logger.Info("Teacher deleting a mark");

            //authentification for teacher
            bool isTeacher = RequestContext.Principal.IsInRole("teacher");
            bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string teacherId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (teacherId != id)
            {
                return Unauthorized();
            }

            MarkDTO mark = markService.GetByID(markId);
            if (mark == null)
            {
                return NotFound();
            }
            markService.Delete(mark.Id);
            return Ok();
        }
    }
}
