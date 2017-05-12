using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5homework1.Models.ValidateAttribute
{
    public class 手機格式Attribute : ValidationAttribute
    {
        
        public  手機格式Attribute() : base("{0}格式範例:0911-111111")
        {
          
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = (string)value;
            if (Regex.IsMatch(str, @"\d{4}-\d{6}") == false)
            {
                var errormessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errormessage);
            }
            return ValidationResult.Success;
        }
    }
}