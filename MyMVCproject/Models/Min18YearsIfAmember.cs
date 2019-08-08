using System;
using System.ComponentModel.DataAnnotations;

namespace MyMVCproject.Models
{
    public class Min18YearsIfAmember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.BirthDay == null)
                return new ValidationResult("Birthdate is Required.");

            var age = DateTime.Today.Year - customer.BirthDay.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}