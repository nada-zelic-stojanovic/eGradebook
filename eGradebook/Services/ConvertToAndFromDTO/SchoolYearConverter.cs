using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class SchoolYearConverter
    {
        public static SchoolYearDTO SchoolYearToSchoolYearDTO(SchoolYear schoolYear)
        {
            SchoolYearDTO schoolYearDTO = new SchoolYearDTO();

            schoolYearDTO.Id = schoolYear.Id;
            schoolYearDTO.Name = schoolYear.Name;
            schoolYearDTO.StartDate = schoolYear.StartDate;
            schoolYearDTO.EndDate = schoolYear.EndDate;

            return schoolYearDTO;
        }

        public static void UpdateSchoolYearWithSchoolYearDTO(SchoolYear schoolYear, SchoolYearDTO schoolYearDTO)
        {
            schoolYear.Name = schoolYearDTO.Name;
            schoolYear.StartDate = schoolYearDTO.StartDate;
            schoolYear.EndDate = schoolYearDTO.EndDate;
        }

        public static SchoolYear SchoolYearDTOToSchoolYear(SchoolYearDTO schoolYearDTO)
        {
            SchoolYear schoolYear = new SchoolYear();

            schoolYear.Id = schoolYearDTO.Id;
            schoolYear.Name = schoolYearDTO.Name;
            schoolYear.StartDate = schoolYearDTO.StartDate;
            schoolYear.EndDate = schoolYearDTO.EndDate;

            return schoolYear;
        }
    }
}