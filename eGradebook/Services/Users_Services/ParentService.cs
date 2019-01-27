using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO.Convet_Users;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.Users_Services
{
    public class ParentService : IParentService
    {
        private IUnitOfWork db;
        private IParentConverter converter;

        public ParentService(IUnitOfWork db, IParentConverter converter)
        {
            this.db = db;
            this.converter = converter;
        }

        public IEnumerable<ParentDTO> Get()
        {
            var parents = db.ParentsRepository.Get();
            if (parents == null)
            {
                return null;
            }
            var parentDTOs = new List<ParentDTO>();
            foreach (Parent parent in parents)
            {
                parentDTOs.Add(converter.ParentToParentDTO(parent));
            }
            return parentDTOs;
        }


        public ParentDTO GetByID(string id)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            if (parent == null)
            {
                return null;
            }
            return converter.ParentToParentDTO(parent);
        }


        public ParentDTO Update(string id, ParentDTO parentDTO)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            converter.UpdateParentWithParentDTO(parent, parentDTO);
            db.ParentsRepository.Update(parent);
            db.Save();
            return converter.ParentToParentDTO(parent);
        }


        public ParentDTO Delete(string id)
        {
            Parent parent = db.ParentsRepository.GetByID(id);
            db.ParentsRepository.Delete(parent);
            db.Save();
            return converter.ParentToParentDTO(parent);
        }
    }
}