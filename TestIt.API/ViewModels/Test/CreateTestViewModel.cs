using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestIt.API.ViewModels.Validations.Test;

namespace TestIt.API.ViewModels.Test
{
    public class CreateTestViewModel : IValidatableObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CreateTestViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }

    }
}
