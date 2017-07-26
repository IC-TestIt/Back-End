using FluentValidation;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.Validations.Test
{
    public class CreateTestViewModelValidator : AbstractValidator<CreateTestViewModel>
    {
        public CreateTestViewModelValidator()
        {
            RuleFor(test => test.Title).NotEmpty().WithMessage("Title cannot be empty");
            RuleFor(test => test.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(test => test.TeacherId).NotEmpty().WithMessage("TeacherId cannot be empty");
        }
    }
}
