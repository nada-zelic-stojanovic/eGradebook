using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface ITeacherGradebookService
    {
        IEnumerable<SchoolClassBasicDTO> GetTeacherTeachingClasses(string teacherId);
        StudentTakesCourseDTO GetStudentsMarksFromCourse(string studentId, int courseId);
        IEnumerable<TeacherTeachesCourseDTO> GetTeacherTeachingCourses(string teacherId);
        StudentTakesCourseDTO GiveStudentAMark(string studentId, int courseId, MarkDTO markDTO);
        IEnumerable<SchoolClassDTO> GetSchoolClassesByTeacher(string teacherId);
        IEnumerable<SchoolClassDTO> GetClassesByTeacherTeachingCourse(string teacherId, int courseId);
    }
}
