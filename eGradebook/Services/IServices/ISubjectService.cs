using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDTO> Get();
        SubjectDTO GetByID(int id);
        SubjectDTO Update(int id, SubjectDTO subjectDTO);
        SubjectDTO Create(SubjectDTO subjectDTO);
        void Delete(int id);
    }
}
