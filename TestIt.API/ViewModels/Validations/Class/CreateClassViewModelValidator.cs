using FluentValidation;
using TestIt.API.ViewModels.Class;

namespace TestIt.API.ViewModels.Validations.Class
{
    public class CreateClassViewModelValidator : AbstractValidator<CreateClassViewModel>
    {
        public CreateClassViewModelValidator()
        {
            RuleFor(newclass => newclass.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(newclass => newclass.TeacherId).NotEmpty().WithMessage("TeacherId cannot be empty");
        }
    }
}
