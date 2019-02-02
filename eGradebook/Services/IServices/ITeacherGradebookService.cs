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
        IEnumerable<SchoolClassBasicDTO> GetTeacherClasses(string teacherId);
        StudentTakesCourseDTO GetStudentsMarksFromCourse(string studentId, int courseId);
        IEnumerable<TeacherTeachesCourseDTO> GetTeacherCourses(string teacherId);
        StudentTakesCourseDTO MarkStudent(string studentId, int courseId, MarkDTO markDTO);
    }
}
