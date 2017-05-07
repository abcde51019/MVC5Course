using MVC5Course.Models.ValidateAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    [MetadataType(typeof(ProductData))]
    public partial class Product : IValidatableObject
    {
        public int 訂單數量
        {
            get
            {
                return this.OrderLine.Count;
                //總計 效能比較
                //return this.OrderLine.Where(x => x.Qty > 400).Count(); //差
                //return this.OrderLine.Where(x => x.Qty > 400).ToList().Count; //差
                //return this.OrderLine.Count(x => x.Qty > 400); //最好
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stock > 10 && Price > 200)
            {
                yield return new ValidationResult("庫存>10價格>200錯囉~~", 
                                                   new string[] { "Stock", "Price" });
            }
            if (Stock > 0 && Active == false)
            {
                yield return new ValidationResult("給我上架喔", new[] { "Active" });
            }
            yield break;
            //throw new NotImplementedException();
        }
    }
    public partial class ProductData
    {
        [Required(ErrorMessage = "請輸入商品名稱")]
        //[MaxWords(10)]
        //[RegularExpression("(.+)-(.+)", ErrorMessage = "名稱內需有-符號")]
        [DisplayName("商品名稱")]
        [商品名稱需包含LIN字元]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "請輸入正確的商品價格1~9999")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [DisplayName("商品價格")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [DisplayName("是否上架")]
        public Nullable<bool> Active { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "請輸入正確的庫存數量0~9999")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [DisplayName("商品庫存")]
        public Nullable<decimal> Stock { get; set; }
    }
}