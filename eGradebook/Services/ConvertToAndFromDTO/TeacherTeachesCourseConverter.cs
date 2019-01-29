using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class TeacherTeachesCourseConverter
    {
        public static TeacherTeachesCourseDTO TeacherTeachescourseToTeacherTeachesCourseDTO(TeacherTeachesCourse ttc)
        {
            TeacherTeachesCourseDTO ttcDTO = new TeacherTeachesCourseDTO();

            ttcDTO.Id = ttc.Id;
            ttcDTO.Teacher = TeacherConverter.TeacherToTeacherDTO(ttc.Teacher);
            ttcDTO.Subject = SubjectConverter.SubjectToSubjectDTO(ttc.Subject);

            return ttcDTO;
        }

        public static void UpdateTeacherTeachesCourseWithTeacherTeachesCourseDTO(TeacherTeachesCourse ttc, TeacherTeachesCourseDTO ttcDTO)
        {
            ttc.Teacher = TeacherConverter.TeacherDTOToTeacher(ttcDTO.Teacher);
            ttc.Subject = SubjectConverter.SubjectDTOToSubject(ttcDTO.Subject);
        }

        public static TeacherTeachesCourse TeacherTeachesCourseDTOtoTeacherTeachesCourse(TeacherTeachesCourseDTO ttcDTO)
        {
            TeacherTeachesCourse ttc = new TeacherTeachesCourse();
            ttc.Id = ttcDTO.Id;
            ttc.Teacher = TeacherConverter.TeacherDTOToTeacher(ttcDTO.Teacher);
            ttc.Subject = SubjectConverter.SubjectDTOToSubject(ttcDTO.Subject);

            return ttc;
        }
    }
}