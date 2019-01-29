using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface ISchoolYearService
    {
        IEnumerable<SchoolYearDTO> Get();
        SchoolYearDTO GetById(int id);
        SchoolYearDTO Update(int id, SchoolYearDTO schoolYearDTO);
        SchoolYearDTO Create(SchoolYearDTO schoolYearDTO);
        void Delete(int id);
    }
}
