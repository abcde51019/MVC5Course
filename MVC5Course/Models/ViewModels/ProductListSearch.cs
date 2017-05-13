using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductListSearch : IValidatableObject
    {
        public string Search { get; set; }
        public int StockS { get; set; }
        public int StockE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (this.StockS > this.StockE)
            {
                yield return new ValidationResult("庫存條件錯誤",new[] { "StockS", "StockE" });
            }
        }
    }
}