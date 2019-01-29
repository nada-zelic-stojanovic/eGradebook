using eGradebook.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class AdminConverter
    {
        public static AdminDTO AdminToAdminDTO(Admin admin)
        {
            AdminDTO adminDTO = new AdminDTO();

            adminDTO.Id = admin.Id;
            adminDTO.FirstName = admin.FirstName;
            adminDTO.LastName = admin.LastName;
            adminDTO.UserName = admin.UserName;
            adminDTO.Email = admin.Email;

            return adminDTO;
        }

        public static void UpdateAdminWithAdminDTO(Admin admin, AdminDTO adminDTO)
        {
            //admin.Id = adminDTO.Id;
            admin.FirstName = adminDTO.FirstName;
            admin.LastName = adminDTO.LastName;
            admin.UserName = adminDTO.UserName;
            admin.Email = adminDTO.Email;

        }
    }
}