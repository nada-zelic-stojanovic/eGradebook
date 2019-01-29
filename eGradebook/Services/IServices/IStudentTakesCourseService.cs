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
        StudentTakesCourseDTO Create(StudentTakesCourseDTO studentCourseDTO);
        StudentTakesCourseDTO Update(int id, StudentTakesCourseDTO studentCourseDTO);
        void Delete(int id);
    }
}
