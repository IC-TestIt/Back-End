using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Exam;

namespace TestIt.API.ViewModels.Validations.Exam
{
    public class CreateExamViewModelValidator : AbstractValidator<CreateExamViewModel>
    {
        public CreateExamViewModelValidator()
        {
            RuleFor(exam => exam.StudentId).NotEmpty().WithMessage("StudentId cannot be empty");
            RuleFor(exam => exam.ClassTestsId).NotEmpty().WithMessage("ClassTestsId cannot be empty");
        }
    }
}
