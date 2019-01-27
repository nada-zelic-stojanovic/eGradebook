using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO.Convet_Users
{
    public class AdminConverter : IAdminConverter
    {
        public AdminDTO AdminToAdminDTO(Admin admin)
        {
            AdminDTO adminDTO = new AdminDTO();

            adminDTO.Id = admin.Id;
            adminDTO.FirstName = admin.FirstName;
            adminDTO.LastName = admin.LastName;
            adminDTO.UserName = admin.UserName;
            adminDTO.Email = admin.Email;

            return adminDTO;
        }

        public void UpdateAdminWithAdminDTO(Admin admin, AdminDTO adminDTO)
        {
            //admin.Id = adminDTO.Id;
            admin.FirstName = adminDTO.FirstName;
            admin.LastName = adminDTO.LastName;
            admin.UserName = adminDTO.UserName;
            admin.Email = adminDTO.Email;

        }
    }
}