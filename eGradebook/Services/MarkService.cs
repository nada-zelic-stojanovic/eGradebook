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
    public class MarkService : IMarkService
    {
        private IUnitOfWork db;
        private IStudentTakesCourseService studentCourseService;

        public MarkService(IUnitOfWork db, IStudentTakesCourseService studentCourseService)
        {
            this.db = db;
            this.studentCourseService = studentCourseService;
        }

        public IEnumerable<MarkDTO> Get()
        {
            var marks = db.MarksRepository.Get();
            if (marks == null)
            {
                return null;
            }
            var marksDTOs = new List<MarkDTO>();
            foreach (Mark mark in marks)
            {
                marksDTOs.Add(MarkConverter.MarkoToMarkDTO(mark));
            }
            return marksDTOs;
        }


        public MarkDTO GetByID(int id)
        {
            Mark mark = db.MarksRepository.GetByID(id);
            if (mark == null)
            {
                return null;
            }
            return MarkConverter.MarkoToMarkDTO(mark);
        }


        public MarkDTO Update(int id, MarkDTO markDTO)
        {
            Mark mark = db.MarksRepository.GetByID(id);
            MarkConverter.UpdateMarkWithMarkDTO(mark, markDTO);
            mark.DateAdded = DateTime.Now;
            db.MarksRepository.Update(mark);
            return MarkConverter.MarkoToMarkDTO(mark);
        }


        public MarkDTO Create(MarkDTO markDTO)
        {
            Mark mark = MarkConverter.MarkDTOToMark(markDTO);
            mark.DateAdded = DateTime.Now;
            db.MarksRepository.Insert(mark);
            db.Save();
            return MarkConverter.MarkoToMarkDTO(mark);
        }


        public void Delete(int id)
        {
            Mark mark = db.MarksRepository.GetByID(id);
            db.MarksRepository.Delete(mark);
            db.Save();
        }
    }
}