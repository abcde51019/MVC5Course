using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductList
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(5)]
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "請輸入正確的商品價格1~9999")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [DisplayName("商品價格")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Range(0,9999)]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [DisplayName("商品庫存")]
        public Nullable<decimal> Stock { get; set; }
    }
}