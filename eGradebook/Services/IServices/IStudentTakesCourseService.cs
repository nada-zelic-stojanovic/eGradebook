using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface IStudentTakesCourseService
    {
        IEnumerable<StudentTakesCourseDTO> Get();
        StudentTakesCourseDTO GetByID(int id);
        StudentTakesCourseDTO Create(string studentId, int courseId);
        StudentTakesCourseDTO Update(int studentCourseId, int courseId);
        void Delete(int id);
    }
}
