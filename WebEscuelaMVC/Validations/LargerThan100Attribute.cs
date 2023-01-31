using System;
using System.ComponentModel.DataAnnotations;

namespace WebEscuelaMVC.Validations
{
    public class LargerThan100Attribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int nro = Convert.ToInt32(value);

            if (nro <= 100)
            {
                return new ValidationResult("El número debe ser mayor a 100.");
            }

            return ValidationResult.Success;
        }

    }
}
