using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services
{
    public class SchoolYearService : ISchoolYearService
    {
        private IUnitOfWork db;
        public SchoolYearService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<SchoolYearDTO> Get()
        {
            var schoolYears = db.SchoolYearsRepository.Get();
            if (schoolYears == null)
            {
                return null;
            }
            var schoolyearDTOs = new List<SchoolYearDTO>();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                schoolyearDTOs.Add(SchoolYearConverter.SchoolYearToSchoolYearDTO(schoolYear));
            }
            return schoolyearDTOs;
        }


        public SchoolYearDTO GetById(int id)
        {
            SchoolYear schoolYear = db.SchoolYearsRepository.GetByID(id);
            if (schoolYear == null)
            {
                return null;
            }
            return SchoolYearConverter.SchoolYearToSchoolYearDTO(schoolYear);
        }


        public SchoolYearDTO Update(int id, SchoolYearDTO schoolYearDTO)
        {
            SchoolYear schoolYear = db.SchoolYearsRepository.GetByID(id);
            SchoolYearConverter.UpdateSchoolYearWithSchoolYearDTO(schoolYear, schoolYearDTO);

            db.SchoolYearsRepository.Update(schoolYear);
            db.Save();
            return SchoolYearConverter.SchoolYearToSchoolYearDTO(schoolYear);
        }

        public SchoolYearDTO Create(SchoolYearDTO schoolYearDTO)
        {
            SchoolYear schoolYear = SchoolYearConverter.SchoolYearDTOToSchoolYear(schoolYearDTO);
            db.SchoolYearsRepository.Insert(schoolYear);
            db.Save();
            return SchoolYearConverter.SchoolYearToSchoolYearDTO(schoolYear);
        }

        public void Delete(int id)
        {
            SchoolYear schoolYear = db.SchoolYearsRepository.GetByID(id);
            db.SchoolYearsRepository.Delete(schoolYear);
            db.Save();
        }
    }
}