using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Question;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.Exam
{
    public class ClassTestsEstimatedCorrectionViewModel
    {
        public ClassTestsEstimatedCorrectionViewModel()
        {
            CorrectedExams = new List<ExamEstimatedCorrectionViewModel>();
        }

        public CorrectionTestViewModel Test { get; set; }
        public IEnumerable<ExamEstimatedCorrectionViewModel> CorrectedExams { get; set; }
    }
}
