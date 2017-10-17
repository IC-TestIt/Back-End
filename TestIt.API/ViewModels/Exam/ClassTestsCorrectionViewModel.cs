using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Question;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.Exam
{
    public class ClassTestsCorrectionViewModel
    {
        public ClassTestsCorrectionViewModel(IEnumerable<CorrectedExamViewModel> correctedExams)
        {
            CorrectedExams = new List<CorrectedExamViewModel>(correctedExams);
        }

        public ReturnTestViewModel Test { get; set; }
        public IEnumerable<CorrectedExamViewModel> CorrectedExams { get; set; }
    }
}
