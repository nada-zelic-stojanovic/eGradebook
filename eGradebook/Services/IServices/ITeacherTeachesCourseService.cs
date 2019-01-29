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
        TeacherTeachesCourseDTO CreateFromExisting(string teacherId, int subjectId);
        TeacherTeachesCourseDTO Create(TeacherTeachesCourseDTO courseDTO);
        TeacherTeachesCourseDTO Update(int id, TeacherTeachesCourseDTO courseDTO);
        void Delete(int id);
    }
}
