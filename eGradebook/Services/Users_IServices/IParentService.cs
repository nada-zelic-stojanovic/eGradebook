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
        IEnumerable<ParentBasicDTO> Get();
        ParentDTO GetByID(string id);
        ParentUpdateDTO Update(string id, ParentUpdateDTO parentDTO);
        void Delete(string id);
    }
}
