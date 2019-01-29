using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface ISchoolClassService
    {
        IEnumerable<SchoolClassDTO> Get();
        SchoolClassDTO GetById(int id);
        SchoolClassDTO Update(int id, SchoolClassDTO schoolClassDTO);
        SchoolClassDTO Create(SchoolClassDTO schoolClassDTO);
        void Delete(int id);

        SchoolClassDTO UpdateSchoolYearWithSchoolClass(int schoolClassId, int schoolYearId);
    }
}
