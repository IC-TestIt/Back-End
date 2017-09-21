using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestIt.API.ViewModels.Validations.Exam;

namespace TestIt.API.ViewModels.Exam
{
    public class CreateExamViewModel : IValidatableObject
    {
        public int StudentId { get; set; }
        public int ClassTestsId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CreateExamViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
