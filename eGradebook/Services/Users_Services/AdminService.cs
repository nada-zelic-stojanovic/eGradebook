using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.Users_Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork db;

        public AdminService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<AdminBasicDTO> Get()
        {
            var admins = db.AdminsRepository.Get();
            if (admins == null)
            {
                return null;
            }
            var adminDTOs = new List<AdminBasicDTO>();
            foreach(Admin admin in admins)
            {
                adminDTOs.Add(AdminConverter.AdminToAdminBasicDTO(admin));
            }
            return adminDTOs;
        }

        public AdminDTO GetByID(string id)
        {
            Admin admin = db.AdminsRepository.GetByID(id);
            if (admin == null)
            {
                return null;
            }
            return AdminConverter.AdminToAdminDTO(admin);
        }

        public AdminDTO Update(string id, AdminDTO adminDTO)
        {
            Admin admin = db.AdminsRepository.GetByID(id);
            if (admin == null)
            {
                return null;
            }
            AdminConverter.UpdateAdminWithAdminDTO(admin, adminDTO);

            db.AdminsRepository.Update(admin);
            db.Save();
            return AdminConverter.AdminToAdminDTO(admin); 
        }

        public void Delete(string id)
        {
            Admin admin = db.AdminsRepository.GetByID(id);

            db.AdminsRepository.Delete(admin);
            db.Save();
        }

    }
}