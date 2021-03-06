﻿using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class ExamRealCorrectionViewModel
    {
        public ExamRealCorrectionViewModel()
        {
            AnsweredQuestions = new List<AnsweredQuestionCorrectionViewModel>();
        }

        public int Id { get; set; }
        public IEnumerable<AnsweredQuestionCorrectionViewModel> AnsweredQuestions { get; set; }

    }

    public class ExamsRealCorrectionViewModel
    {
        public ExamsRealCorrectionViewModel()
        {
            Corrections = new List<ExamRealCorrectionViewModel>();
        }

        public IEnumerable<ExamRealCorrectionViewModel> Corrections { get; set; }
    }
}
