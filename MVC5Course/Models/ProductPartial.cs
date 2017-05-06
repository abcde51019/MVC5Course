using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    [MetadataType(typeof(ProductData))]
    public partial class Product
    {
    }
    public partial class ProductData
    {
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MinLength(3, ErrorMessage = "最少輸入3字元"), MaxLength(20, ErrorMessage = "最多不超過20字元")]
        [RegularExpression("(.+)-(.+)", ErrorMessage = "名稱內需有-符號")]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "請輸入正確的商品價格1~9999")]
        [DisplayFormat(DataFormatString ="{0:0}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "請輸入正確的庫存數量0~9999")]
        [DisplayFormat(DataFormatString = "{0:0}",ApplyFormatInEditMode = true)]
        public Nullable<decimal> Stock { get; set; }
    }
}