using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConcessionariaApp.Application.Attributes
{
    public class AnoFundacaoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var anoFundacao = (int)value;
            var AnoFundacaoPrimeiraFabricante = 1856;
            if (anoFundacao < AnoFundacaoPrimeiraFabricante)
            {
                return new ValidationResult("O ano é inválido.");
            }

            if (anoFundacao > DateTime.Now.Year)
            {
                return new ValidationResult("O ano de fundação não pode estar no futuro.");
            }

            return ValidationResult.Success;
        }
    }
}
