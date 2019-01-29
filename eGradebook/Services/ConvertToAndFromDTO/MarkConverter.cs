using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class MarkConverter
    {
        public static MarkDTO MarkoToMarkDTO(Mark mark)
        {
            MarkDTO markDTO = new MarkDTO();

            markDTO.Id = mark.Id;
            markDTO.Student_Course = StudentTakesCourseConverter.StudentTakesCourseToStudentTakesCourseDTO(mark.Student_Course);
            markDTO.Value = mark.Value;
            markDTO.DateAdded = mark.DateAdded;

            return markDTO;
        }

        public static void UpdateMarkWithMarkDTO(Mark mark, MarkDTO markDTO)
        {
            mark.Student_Course = StudentTakesCourseConverter.StudentTakesCourseDTOToStudentTakesCourse(markDTO.Student_Course);
            mark.Value = markDTO.Value;
            mark.DateAdded = markDTO.DateAdded;
        }

        public static Mark MarkDTOToMark(MarkDTO markDTO)
        {
            Mark mark = new Mark();

            mark.Id = markDTO.Id;
            mark.Student_Course = StudentTakesCourseConverter.StudentTakesCourseDTOToStudentTakesCourse(markDTO.Student_Course);
            mark.Value = markDTO.Value;
            mark.DateAdded = markDTO.DateAdded;

            return mark;
        }
    }
}