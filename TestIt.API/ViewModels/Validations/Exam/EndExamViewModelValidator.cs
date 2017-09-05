using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Exam;

namespace TestIt.API.ViewModels.Validations.Exam
{
    public class EndExamViewModelValidator : AbstractValidator<EndExamViewModel>
    {
        public EndExamViewModelValidator()
        {
            
        }
    }
}
