using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestIt.API.ViewModels.Validations.Question;


namespace TestIt.API.ViewModels.Question
{
    public class CreateQuestionViewModel : IValidatableObject
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public int TestId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CreateQuestionViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
