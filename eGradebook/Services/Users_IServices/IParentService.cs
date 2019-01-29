using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.Users_IServices
{
    public interface IParentService
    {
        IEnumerable<ParentDTO> Get();
        ParentDTO GetByID(string id);
        ParentDTO Update(string id, ParentDTO parentDTO);
        void Delete(string id);
    }
}
