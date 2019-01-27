using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.ConvertToAndFromDTO.Convet_Users
{
    public interface IParentConverter
    {
        ParentDTO ParentToParentDTO(Parent parent);
        void UpdateParentWithParentDTO(Parent parent, ParentDTO parentDTO);
        Parent ParentDTOToParent(ParentDTO parentDTO);
    }
}
