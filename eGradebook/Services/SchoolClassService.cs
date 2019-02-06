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
    public class SchoolClassService : ISchoolClassService
    {
        private IUnitOfWork db;
        private ISchoolYearService schoolYearService;
        public SchoolClassService(IUnitOfWork db, ISchoolYearService schoolYearService)
        {
            this.db = db;
            this.schoolYearService = schoolYearService;
        }

        public IEnumerable<SchoolClassBasicDTO> Get()
        {
            var schoolClasses = db.SchoolClassesRepository.Get();
            if (schoolClasses == null)
            {
                return null;
            }
            var schoolClassesDTOs = new List<SchoolClassBasicDTO>();
            foreach (SchoolClass schoolClass in schoolClasses)
            {
                schoolClassesDTOs.Add(SchoolClassConverter.SchoolClassToSchoolClassBasicDTO(schoolClass));
            }
            return schoolClassesDTOs;
        }


        public SchoolClassDTO GetById(int id)
        {
            SchoolClass schoolClass = db.SchoolClassesRepository.GetByID(id);
            if (schoolClass == null)
            {
                return null;
            }
            return SchoolClassConverter.SchoolClassToSchoolClassDTO(schoolClass);
        }


        public SchoolClassBasicDTO Update(int id, SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            SchoolClass schoolClass = db.SchoolClassesRepository.GetByID(id);
            SchoolClassConverter.UpdateSchoolClassWithSchoolClassDTO(schoolClass, schoolClassDTO);
            db.SchoolClassesRepository.Update(schoolClass);
            db.Save();
            return SchoolClassConverter.SchoolClassToSchoolClassBasicDTO(schoolClass);
        }


        public SchoolClassCreateAndUpdateDTO Create(SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            SchoolClass schoolClass = SchoolClassConverter.SchoolClassCreateAndUpdateDTOToSchoolClass(schoolClassDTO);
            db.SchoolClassesRepository.Insert(schoolClass);
            schoolClass.SchoolYear = new SchoolYear()
            {
                Name = "SchoolYear to be added",
                StartDate = DateTime.Now,
                EndDate = new DateTime(3000, 12, 31)
            };
            db.Save();
            return SchoolClassConverter.SchoolClassToSchoolClassCreateAndUpdateDTO(schoolClass);
        }


        public void Delete(int id)
        {
            SchoolClass schoolClass = db.SchoolClassesRepository.GetByID(id);
            db.SchoolClassesRepository.Delete(schoolClass);
            db.Save();
        }


        public SchoolClassDTO UpdateSchoolClassWithSchoolYear(int schoolClassId, int schoolYearId)
        {
            SchoolClass schoolClass = db.SchoolClassesRepository.GetByID(schoolClassId);
            SchoolYear schoolYear = db.SchoolYearsRepository.GetByID(schoolYearId);
            schoolClass.SchoolYear = schoolYear;
            db.SchoolClassesRepository.Update(schoolClass);
            db.Save();
            return SchoolClassConverter.SchoolClassToSchoolClassDTO(schoolClass);
        }
    }
}