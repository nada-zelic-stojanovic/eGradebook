using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class SchoolClassConverter
    {
        public static SchoolClassDTO SchoolClassToSchoolClassDTO(SchoolClass schoolClass)
        {
            SchoolClassDTO schoolClassDTO = new SchoolClassDTO();

            schoolClassDTO.Id = schoolClass.Id;
            schoolClassDTO.Grade = schoolClass.Grade;
            schoolClassDTO.Section = schoolClass.Section;
            schoolClassDTO.SchoolYear = SchoolYearConverter.SchoolYearToSchoolYearDTO(schoolClass.SchoolYear);
            schoolClassDTO.Students = schoolClass.Students.Select(s => StudentConverter.StudentToStudentBasicDTO(s));
            schoolClassDTO.Courses = schoolClass.Courses.Select(c => TeacherTeachesCourseConverter.TeacherTeachescourseToTeacherTeachesCourseDTO(c));

            return schoolClassDTO;
        }


        public static void UpdateSchoolClassWithSchoolClassDTO(SchoolClass schoolClass, SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            schoolClass.Grade = schoolClassDTO.Grade;
            schoolClass.Section = schoolClassDTO.Section;
            //schoolClass.SchoolYear = SchoolYearConverter.SchoolYearDTOToSchoolYear(schoolClassDTO.SchoolYear);
        }

        public static SchoolClass SchoolClassDTOToSchoolClass(SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            SchoolClass schoolClass = new SchoolClass();

            schoolClass.Id = schoolClassDTO.Id;
            schoolClass.Grade = schoolClassDTO.Grade;
            schoolClass.Section = schoolClassDTO.Section;
            //schoolClass.SchoolYear = SchoolYearConverter.SchoolYearDTOToSchoolYear(schoolClassDTO.SchoolYear);
            //schoolClass.Students = schoolClassDTO.Students;
            //schoolClass.Courses_Teachers = schoolClassDTO.Courses_Teachers;

            return schoolClass;
        }

        public static SchoolClassBasicDTO SchoolClassToSchoolClassBasicDTO(SchoolClass schoolClass)
        {
            SchoolClassBasicDTO schoolClassDTO = new SchoolClassBasicDTO();
            schoolClassDTO.Id = schoolClass.Id;
            schoolClassDTO.Grade = schoolClass.Grade;
            schoolClassDTO.Section = schoolClass.Section;
            schoolClassDTO.SchoolYear = schoolClass.SchoolYear.Name;
            return schoolClassDTO;
        }

        public static SchoolClass SchoolClassCreateAndUpdateDTOToSchoolClass(SchoolClassCreateAndUpdateDTO schoolClassDTO)
        {
            SchoolClass schoolClass = new SchoolClass();
            schoolClass.Grade = schoolClassDTO.Grade;
            schoolClass.Section = schoolClassDTO.Section;
            return schoolClass;
        }

        public static SchoolClassCreateAndUpdateDTO SchoolClassToSchoolClassCreateAndUpdateDTO(SchoolClass schoolClass)
        {
            SchoolClassCreateAndUpdateDTO schoolClassDTO = new SchoolClassCreateAndUpdateDTO();
            schoolClassDTO.Id = schoolClass.Id;
            schoolClassDTO.Grade = schoolClass.Grade;
            schoolClassDTO.Section = schoolClass.Section;
            return schoolClassDTO;
        }
    }
}