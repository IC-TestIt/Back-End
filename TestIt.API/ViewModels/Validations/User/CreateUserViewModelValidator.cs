using FluentValidation;
using TestIt.API.ViewModels.User;

namespace TestIt.API.ViewModels.Validations.User
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(user => user.Identifyer).NotEmpty().WithMessage("Identifyer cannot be empty");
        }
    }
}
