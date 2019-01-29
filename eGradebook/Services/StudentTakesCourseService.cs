using eGradebook.Models;
using eGradebook.Models.DTOs;
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
    public class StudentTakesCourseService : IStudentTakesCourseService
    {
        private IUnitOfWork db;
        private ITeacherTeachesCourseService courseService;
        private IStudentService studentService;
        public StudentTakesCourseService(IUnitOfWork db, ITeacherTeachesCourseService courseService, IStudentService studentService)
        {
            this.db = db;
            this.courseService = courseService;
            this.studentService = studentService;
        }

        public IEnumerable<StudentTakesCourseDTO> Get()
        {
            var studentCourses = db.StudentTakesCourseRepository.Get();
            if (studentCourses == null)
            {
                return null;
            }
            var studentCoursesDTOs = new List<StudentTakesCourseDTO>();
            foreach (StudentTakesCourse studentCourse in studentCourses)
            {
                studentCoursesDTOs.Add(StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(studentCourse));
            }
            return studentCoursesDTOs;
        }


        public StudentTakesCourseDTO GetByID(int id)
        {
            StudentTakesCourse studentCourse = db.StudentTakesCourseRepository.GetByID(id);
            if (studentCourse == null)
            {
                return null;
            }
            return StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(studentCourse);
        }


        public StudentTakesCourseDTO Create(StudentTakesCourseDTO studentCourseDTO)
        {
            StudentTakesCourse studentCourse = StudentTakesCourseConverter.StudentTakesCourseDTOToStudentTakesCourse(studentCourseDTO);
            db.StudentTakesCourseRepository.Insert(studentCourse);
            db.Save();
            return StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(studentCourse);
        }


        public StudentTakesCourseDTO Update(int id, StudentTakesCourseDTO studentCourseDTO)
        {
            StudentTakesCourse studentCourse = db.StudentTakesCourseRepository.GetByID(id);
            StudentTakesCourseConverter.UpdateStudentTakesCourseWithStudentTakesCourseDTO(studentCourse, studentCourseDTO);
            db.StudentTakesCourseRepository.Update(studentCourse);
            db.Save();
            return StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(studentCourse);
        }


        public void Delete(int id)
        {
            StudentTakesCourse studentCourse = db.StudentTakesCourseRepository.GetByID(id);
            db.StudentTakesCourseRepository.Delete(studentCourse);
            db.Save();
        }
    }
}