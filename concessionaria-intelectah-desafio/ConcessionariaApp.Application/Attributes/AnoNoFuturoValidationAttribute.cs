using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Attributes
{
    public class AnoNoFuturoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var anoFundacao = (int)value;
            
            if (anoFundacao > DateTime.Now.Year)
            {
                return new ValidationResult("O ano não pode estar no futuro.");
            }

            return ValidationResult.Success;
        }
    }
}
