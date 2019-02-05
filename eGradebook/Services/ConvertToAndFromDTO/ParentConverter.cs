using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class ParentConverter
    {
        public static ParentDTO ParentToParentDTO(Parent parent)
        {
            ParentDTO parentDTO = new ParentDTO();

            parentDTO.Id = parent.Id;
            parentDTO.FirstName = parent.FirstName;
            parentDTO.LastName = parent.LastName;
            parentDTO.UserName = parent.UserName;
            parentDTO.Email = parent.Email;
            parentDTO.Children = parent.Children.Select(c=> StudentConverter.StudentToStudentBasicDTO(c));

            return parentDTO;
        }

        public static void UpdateParentWithParentDTO(Parent parent, ParentUpdateDTO parentDTO)
        {
            parent.FirstName = parentDTO.FirstName;
            parent.LastName = parentDTO.LastName;
            parent.UserName = parentDTO.UserName;
            parent.Email = parentDTO.Email;
        }

        public static Parent ParentDTOToParent(ParentDTO parentDTO)
        {
            Parent parent = new Parent();

            parent.Id = parentDTO.Id;
            parent.FirstName = parentDTO.FirstName;
            parent.LastName = parentDTO.LastName;
            parent.UserName = parentDTO.UserName;
            parent.Email = parentDTO.Email;
            //parent.Children = parentDTO.Children;

            return parent;
        }

        public static ParentBasicDTO ParentToParentBasicDTO(Parent parent)
        {
            ParentBasicDTO parentDTO = new ParentBasicDTO();
            parentDTO.Id = parent.Id;
            parentDTO.FirstName = parent.FirstName;
            parentDTO.LastName = parent.LastName;
            return parentDTO;
        }

        public static ParentUpdateDTO ParentToParentUpdateDTO(Parent parent)
        {
            ParentUpdateDTO parentDTO = new ParentUpdateDTO();
            parentDTO.FirstName = parent.FirstName;
            parentDTO.LastName = parent.LastName;
            parentDTO.UserName = parent.UserName;
            parentDTO.Email = parent.Email;
            return parentDTO;
        }
    }
}