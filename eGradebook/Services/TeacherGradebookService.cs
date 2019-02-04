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
using System.Web.Http;

namespace eGradebook.Services
{
    public class TeacherGradebookService : ITeacherGradebookService
    {
        private IUnitOfWork db;
        private ITeacherService teacherService;
        private IMarkService markService;
        private ITeacherTeachesCourseService courseService;
        private IStudentTakesCourseService studentCourseService;
        private ISchoolClassService schoolClassService;

        public TeacherGradebookService(IUnitOfWork db, IMarkService markService, ITeacherTeachesCourseService courseService, IStudentTakesCourseService studentCourseService, ISchoolClassService schoolClassService, ITeacherService teacherService)
        {
            this.markService = markService;
            this.courseService = courseService;
            this.studentCourseService = studentCourseService;
            this.schoolClassService = schoolClassService;
            this.teacherService = teacherService;
            this.db = db;
        }


        //get list of classes in which teacher teaches
        public IEnumerable<SchoolClassBasicDTO> GetTeacherClasses(string teacherId)
        {
            var schoolClasses = db.SchoolClassesRepository.Get();
            var teacherClasses = new List<SchoolClass>();
            foreach (SchoolClass schoolClass in schoolClasses)
            {
                foreach (TeacherTeachesCourse tc in schoolClass.Courses)
                {
                    if (tc.Teacher.Id == teacherId)
                    {
                        teacherClasses.Add(schoolClass);
                    }
                }
            }
            var teacherClassesDTO = new List<SchoolClassBasicDTO>();
            foreach (SchoolClass tc in teacherClasses)
            {
                teacherClassesDTO.Add(SchoolClassConverter.SchoolClassToSchoolClassBasicDTO(tc));
            }


            return teacherClassesDTO;
        }


        //get list of courses taught by teacher
        public IEnumerable<TeacherTeachesCourseDTO> GetTeacherCourses(string teacherId)
        {
            var teacherCourses = db.TeacherTeachesCourseRepository.Get().Where(x => x.Teacher.Id == teacherId);
            var teacherCoursesDTO = new List<TeacherTeachesCourseDTO>();
            foreach (TeacherTeachesCourse tc in teacherCourses)
            {
                teacherCoursesDTO.Add(TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(tc));
            }
            return teacherCoursesDTO;
        }

        //get student's marks from certain course
        public StudentTakesCourseDTO GetStudentsMarksFromCourse(string studentId, int courseId)
        {
            StudentTakesCourse stc = db.StudentTakesCourseRepository
                .Get()
                .FirstOrDefault(x => x.Course.Id == courseId && x.Student.Id == studentId);
            return StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(stc);
        }
        
        //create a student's mark
        public StudentTakesCourseDTO MarkStudent(string studentId, int courseId, MarkDTO markDTO)
        {
            Mark mark = MarkConverter.MarkDTOToMark(markDTO);
            mark.DateAdded = DateTime.Now;
            db.MarksRepository.Insert(mark);

            StudentTakesCourse stc = db.StudentTakesCourseRepository
                .Get()
                .FirstOrDefault(x => x.Course.Id == courseId && x.Student.Id == studentId);
            if (stc == null)
            {
                return null;
            }
            stc.StudentsMarksFromCourse.Add(mark);
            db.StudentTakesCourseRepository.Update(stc);
            db.Save();
            return StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(stc);
        }
       
    }
}