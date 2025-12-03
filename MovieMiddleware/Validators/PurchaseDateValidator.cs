using System.ComponentModel.DataAnnotations;

namespace MovieMiddleware.Validators;

public class PurchaseDateValidator: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date && date.Date < DateTime.Today)
            return new ValidationResult("Purchase date cannot be before today.");

        return ValidationResult.Success;
    }
}