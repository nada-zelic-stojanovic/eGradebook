using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGradebook.Services.IServices
{
    public interface IStudentGradebookService
    {
        StudentGradebookDTO GetStudentGradebook(string studentId);
    }
}
