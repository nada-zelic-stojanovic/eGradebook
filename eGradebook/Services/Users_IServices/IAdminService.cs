using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.Users_IServices
{
    public interface IAdminService
    {
        IEnumerable<AdminDTO> Get();
        AdminDTO GetByID(string id);
        AdminDTO Update(string id, AdminDTO adminDTO);
        void Delete(string id);
    }
}
