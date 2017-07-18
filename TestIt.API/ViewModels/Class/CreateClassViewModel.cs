using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestIt.API.ViewModels.Validations.Class;

namespace TestIt.API.ViewModels.Class
{
    public class CreateClassViewModel : IValidatableObject
    {
        public string Description { get; set; }
        public int TeacherId { get; set; }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var validator = new CreateClassViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

}
