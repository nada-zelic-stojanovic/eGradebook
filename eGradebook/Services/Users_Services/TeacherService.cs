using eGradebook.Models.UserModels;
using eGradebook.Models.UserModels.UserDTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
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

        public TeacherService(IUnitOfWork db)
        {
            this.db = db;
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
                teacherDTOs.Add(TeacherConverter.TeacherToTeacherDTO(teacher));
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
            return TeacherConverter.TeacherToTeacherDTO(teacher);
        }

        public TeacherDTO Update(string id, TeacherDTO teacherDTO)
        {
            Teacher teacher = db.TeachersRepository.GetByID(id);
            TeacherConverter.UpdateTeacherWithTeacherDTO(teacher, teacherDTO);
            db.TeachersRepository.Update(teacher);
            db.Save();
            return TeacherConverter.TeacherToTeacherDTO(teacher);
        }

        public void Delete(string id)
        {
            Teacher teacher = db.TeachersRepository.GetByID(id);
            db.TeachersRepository.Delete(teacher);
            db.Save();
        }
    }
}