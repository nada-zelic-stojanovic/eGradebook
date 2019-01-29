using eGradebook.Models;
using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Services.ConvertToAndFromDTO
{
    public class SubjectConverter
    {
        public static SubjectDTO SubjectToSubjectDTO(Subject subject)
        {
            SubjectDTO subjectDTO = new SubjectDTO();

            subjectDTO.Id = subject.Id;
            subjectDTO.Name = subject.Name;
            subjectDTO.Grade = subject.Grade;
            subjectDTO.ClassesPerWeek = subject.ClassesPerWeek;

            return subjectDTO;
        }

        public static void UpdateSubjectWithSubjectDTO(Subject subject, SubjectDTO subjectDTO)
        {
            subject.Name = subjectDTO.Name;
            subject.Grade = subjectDTO.Grade;
            subject.ClassesPerWeek = subjectDTO.ClassesPerWeek;
        }

        public static Subject SubjectDTOToSubject(SubjectDTO subjectDTO)
        {
            Subject subject = new Subject();

            subject.Id = subjectDTO.Id;
            subject.Name = subjectDTO.Name;
            subject.Grade = subjectDTO.Grade;
            subject.ClassesPerWeek = subjectDTO.ClassesPerWeek;

            return subject;
        }
    }
}