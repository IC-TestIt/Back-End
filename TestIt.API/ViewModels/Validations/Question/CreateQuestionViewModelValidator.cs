using FluentValidation;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Validations.Question
{
    public class CreateQuestionViewModelValidator : AbstractValidator<BaseQuestionViewModel>
    {
        public CreateQuestionViewModelValidator()
        {
            RuleFor(question => question.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(question => question.TestId).NotEmpty().WithMessage("TestId cannot be empty");
            RuleFor(question => question.Value).NotEmpty().WithMessage("Value cannot be empty");
        }
    }
}