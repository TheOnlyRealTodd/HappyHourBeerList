using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Models
{
    public class IbuLimitations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var beer = (Beer)validationContext.ObjectInstance;

            if (beer.Ibu > 100 || beer.Ibu < 0)
            {
                return new ValidationResult("Ibu must be 0-100");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}