using FluentValidation;
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
