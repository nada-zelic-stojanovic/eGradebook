using eGradebook.Models.UserModels;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO.Convet_Users;
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
        private IAdminConverter converter;

        public AdminService(IUnitOfWork db, IAdminConverter converter)
        {
            this.db = db;
            this.converter = converter;
        }

        public IEnumerable<AdminDTO> Get()
        {
            var admins = db.AdminsRepository.Get();
            if (admins == null)
            {
                return null;
            }
            var adminDTOs = new List<AdminDTO>();
            foreach(Admin admin in admins)
            {
                adminDTOs.Add(converter.AdminToAdminDTO(admin));
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
            return converter.AdminToAdminDTO(admin);
        }

        public AdminDTO Update(string id, AdminDTO adminDTO)
        {
            Admin admin = db.AdminsRepository.GetByID(id);
            converter.UpdateAdminWithAdminDTO(admin, adminDTO);

            db.AdminsRepository.Update(admin);
            db.Save();
            return converter.AdminToAdminDTO(admin); 
        }

        public AdminDTO Delete(string id)
        {
            Admin admin = db.AdminsRepository.GetByID(id);
            db.AdminsRepository.Delete(admin);
            db.Save();
            return converter.AdminToAdminDTO(admin);
        }

    }
}