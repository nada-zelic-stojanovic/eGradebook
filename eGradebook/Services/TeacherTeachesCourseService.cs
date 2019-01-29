using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.IServices;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services
{
    public class TeacherTeachesCourseService : ITeacherTeachesCourseService
    {
        private IUnitOfWork db;
        private ITeacherService teacherService;
        private ISubjectService subjectService;
        public TeacherTeachesCourseService(IUnitOfWork db, ITeacherService teacherService, ISubjectService subjectService)
        {
            this.db = db;
            this.teacherService = teacherService;
            this.subjectService = subjectService;
        }

        public IEnumerable<TeacherTeachesCourseDTO> Get()
        {
            var courses = db.TeacherTeachesCourseRepository.Get();
            if (courses == null)
            {
                return null;
            }
            var coursesDTOs = new List<TeacherTeachesCourseDTO>();
            foreach (TeacherTeachesCourse course in courses)
            {
                coursesDTOs.Add(TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(course));
            }
            return coursesDTOs;
        }

        public TeacherTeachesCourseDTO GetByID(int id)
        {
            TeacherTeachesCourse course = db.TeacherTeachesCourseRepository.GetByID(id);
            if (course == null)
            {
                return null;
            }
            return TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(course);
        }

        public TeacherTeachesCourseDTO CreateFromExisting(string teacherId, int subjectId)
        {
            TeacherTeachesCourse course = new TeacherTeachesCourse();
            course.Teacher = TeacherConverter.TeacherDTOToTeacher(teacherService.GetByID(teacherId));
            course.Subject = SubjectConverter.SubjectDTOToSubject(subjectService.GetByID(subjectId));

            db.TeacherTeachesCourseRepository.Insert(course);
            db.Save();
            return TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(course);
        }

        public TeacherTeachesCourseDTO Create(TeacherTeachesCourseDTO courseDTO)
        {
            TeacherTeachesCourse course = TeacherTeachesCourseConverter.TeacherTeachesCourseDTOtoTeacherTeachesCourse(courseDTO);
            db.TeacherTeachesCourseRepository.Insert(course);
            db.Save();
            return TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(course);
        }

        public TeacherTeachesCourseDTO Update(int id, TeacherTeachesCourseDTO courseDTO)
        {
            TeacherTeachesCourse course = db.TeacherTeachesCourseRepository.GetByID(id);
            TeacherTeachesCourseConverter.UpdateTeacherTeachesCourseWithTeacherTeachesCourseDTO(course, courseDTO);
            db.TeacherTeachesCourseRepository.Update(course);
            db.Save();
            return TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(course);
        }

        public void Delete(int id)
        {
            TeacherTeachesCourse course = db.TeacherTeachesCourseRepository.GetByID(id);
            db.TeacherTeachesCourseRepository.Delete(course);
            db.Save();
        }

    }
}