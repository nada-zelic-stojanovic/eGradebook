using eGradebook.Models.DTOs;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface ITeacherTeachesCourseService
    {
        IEnumerable<TeacherTeachesCourseDTO> Get();
        TeacherTeachesCourseDTO GetByID(int id);
        TeacherTeachesCourseDTO Create(string teacherId, int subjectId);
        TeacherTeachesCourseDTO Update(int courseId, string teacherId);
        void Delete(int id);
    }
}
