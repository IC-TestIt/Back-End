﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestIt.API.ViewModels.Validations.User;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.User
{
    public class CreateUserViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int IdentifyerType { get; set; }
        public Organization Organization { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CreateUserViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}