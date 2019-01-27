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
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork db;
        private ITeacherConverter converter;

        public TeacherService(IUnitOfWork db, ITeacherConverter converter)
        {
            this.db = db;
            this.converter = converter;
        }

        public IEnumerable<TeacherDTO> Get()
        {
            var teachers = db.TeachersRepository.Get();
            if (teachers == null)
            {
                return null;
            }
            var teacherDTOs = new List<TeacherDTO>();
            foreach (Teacher teacher in teachers)
            {
                teacherDTOs.Add(converter.TeacherToTeacherDTO(teacher));
            }
            return teacherDTOs;
        }

        public TeacherDTO GetByID(string id)
        {
            Teacher teacher = db.TeachersRepository.GetByID(id);
            if (teacher == null)
            {
                return null;
            }
            return converter.TeacherToTeacherDTO(teacher);
        }

        public TeacherDTO Update(string id, TeacherDTO teacherDTO)
        {
            Teacher teacher = db.TeachersRepository.GetByID(id);
            converter.UpdateTeacherWithTeacherDTO(teacher, teacherDTO);
            db.TeachersRepository.Update(teacher);
            db.Save();
            return converter.TeacherToTeacherDTO(teacher);
        }

        public TeacherDTO Delete(string id)
        {
            Teacher teacher = db.TeachersRepository.GetByID(id);
            db.TeachersRepository.Delete(teacher);
            db.Save();
            return converter.TeacherToTeacherDTO(teacher);
        }
    }
}