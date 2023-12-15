using System.ComponentModel.DataAnnotations;

namespace WebDipendentiDbF.Validations
{
    public class PreviousDate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           if (value is  DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult("La data deve essere odierna o precedente");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Deve essere una data");
        }

    }
}
