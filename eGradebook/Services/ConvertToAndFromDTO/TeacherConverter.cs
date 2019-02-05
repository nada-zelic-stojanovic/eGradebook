using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class TeacherConverter
    {
        public static TeacherDTO TeacherToTeacherDTO(Teacher teacher)
        {
            TeacherDTO teacherDTO = new TeacherDTO();

            teacherDTO.Id = teacher.Id;
            teacherDTO.FirstName = teacher.FirstName;
            teacherDTO.LastName = teacher.LastName;
            teacherDTO.UserName = teacher.UserName;
            teacherDTO.Email = teacher.Email;
            teacherDTO.TeacherTeachesCourses = teacher.TeacherTeachesCourses.Select(x => TeacherTeachesCourseConverter.TeacherTeachesCourseToTeacherTeachesCourseBasicDTO(x));

            return teacherDTO;
        }

        public static void UpdateTeacherWithTeacherDTO(Teacher teacher, TeacherDTO teacherDTO)
        {
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;
            teacher.UserName = teacherDTO.UserName;
            teacher.Email = teacherDTO.Email;
        }

        public static Teacher TeacherDTOToTeacher(TeacherDTO teacherDTO)
        {
            Teacher teacher = new Teacher();

            teacher.Id = teacherDTO.Id;
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;
            teacher.UserName = teacherDTO.UserName;
            teacher.Email = teacherDTO.Email;

            return teacher;
        }

        public static TeacherBasicDTO TeacherToTeacherBasicDTO(Teacher teacher)
        {
            TeacherBasicDTO teacherDTO = new TeacherBasicDTO();
            teacherDTO.Id = teacher.Id;
            teacherDTO.FirstName = teacher.FirstName;
            teacherDTO.LastName = teacher.LastName;
            return teacherDTO;
        }

        public static Teacher TeacherBasicDTOToTeacher(TeacherBasicDTO teacherDTO)
        {
            Teacher teacher = new Teacher();

            teacher.Id = teacherDTO.Id;
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;

            return teacher;
        }
    }
}