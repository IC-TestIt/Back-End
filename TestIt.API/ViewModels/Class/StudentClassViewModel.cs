using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.ClassStudents
{
    public class StudentClassViewModel
    {
        public StudentClassViewModel()
        {
            CorrectedStudentTests = new List<CorrectedStudentTestsViewModel>();
        }

        public int ClassId { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }

        public IEnumerable<CorrectedStudentTestsViewModel> CorrectedStudentTests { get; set; }

    }
}
