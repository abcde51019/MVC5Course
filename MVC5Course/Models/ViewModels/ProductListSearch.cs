using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductListSearch : IValidatableObject
    {
        public ProductListSearch()
        {
            this.StockS = 0;
            this.StockE = 500;
        }
        public string Search { get; set; }
        public int? StockS { get; set ; }
        public int? StockE { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (this.StockE < this.StockS)
            {
                yield return new ValidationResult("庫存資料篩選條件錯誤", new string[] { "StockS", "StockE" });
            }
        }
    }
}