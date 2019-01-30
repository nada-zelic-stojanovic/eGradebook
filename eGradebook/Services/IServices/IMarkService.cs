using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface IMarkService
    {
        IEnumerable<MarkDTO> Get();
        MarkDTO GetByID(int id);
        MarkDTO Update(int id, MarkDTO markDTO);
        MarkDTO Create(MarkDTO markDTO);
        void Delete(int id);
    }
}
