using eGradebook.Models;
using eGradebook.Models.DTOs;
using eGradebook.Repositories;
using eGradebook.Services.ConvertToAndFromDTO;
using eGradebook.Services.IServices;
using eGradebook.Services.Users_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services
{
    public class SubjectService : ISubjectService
    {
        private IUnitOfWork db;
        public SubjectService(IUnitOfWork db)
        {
            this.db = db;     
        }

        public IEnumerable<SubjectDTO> Get()
        {
            var subjects = db.SubjectsRepository.Get();
            if (subjects == null)
            {
                return null;
            }
            var subjectsDTOs = new List<SubjectDTO>();
            foreach (Subject subject in subjects)
            {
                subjectsDTOs.Add(SubjectConverter.SubjectToSubjectDTO(subject));
            }
            return subjectsDTOs;
        }

        public SubjectDTO GetByID(int id)
        {
            Subject subject = db.SubjectsRepository.GetByID(id);
            if (subject == null)
            {
                return null;
            }
            return SubjectConverter.SubjectToSubjectDTO(subject);
        }

        public SubjectDTO Update(int id, SubjectDTO subjectDTO)
        {
            Subject subject = db.SubjectsRepository.GetByID(id);
            SubjectConverter.UpdateSubjectWithSubjectDTO(subject, subjectDTO);
            db.SubjectsRepository.Update(subject);
            db.Save();
            return SubjectConverter.SubjectToSubjectDTO(subject);
        }

        public SubjectDTO Create(SubjectDTO subjectDTO)
        {
            Subject subject = SubjectConverter.SubjectDTOToSubject(subjectDTO);
            db.SubjectsRepository.Insert(subject);
            db.Save();
            return SubjectConverter.SubjectToSubjectDTO(subject);
        }

        public void Delete(int id)
        {
            Subject subject = db.SubjectsRepository.GetByID(id);

            var courses = db.TeacherTeachesCourseRepository.Get().Where(x => x.Subject.Id == id);
            if (courses != null)
            {
                throw new Exception("Cannot delete subject.");
            }
            db.SubjectsRepository.Delete(subject);
            db.Save();
        }
    }
}