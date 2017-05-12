using MVC5homework1.Models.ValidateAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5homework1.Models
{
    [MetadataType(typeof(客戶資料管理))]
    public partial class 客戶資料 
    {
    }
    public partial class 客戶資料管理
    {
        [Required]
        public string 客戶名稱 { get; set; }
        [Required]
        [MinLength(8),MaxLength(8)]
        public string 統一編號 { get; set; }
        [Required]
        [手機格式Attribute]
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        [Required]
        public string 地址 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    [MetadataType(typeof(客戶聯絡人管理))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new CustomerEntities();
            var Count = db.客戶聯絡人.Count(x => x.Email == Email && x.客戶Id == 客戶Id);
            if (Count > 0)
            {
                yield return new ValidationResult("已有相同Email，請重新輸入",
                                                   new string[] { "Email" });
            }
            yield break;
        }
    }
    public partial class 客戶聯絡人管理
    {
        public int Id { get; set; }
        public string 職稱 { get; set; }
        [Required]
        [MaxLength(20)]
        public string 姓名 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [手機格式Attribute]
        public string 手機 { get; set; }
        public string 電話 { get; set; }
    }

    [MetadataType(typeof(客戶銀行資訊管理))]
    public partial class 客戶銀行資訊
    {
    }
    public partial class 客戶銀行資訊管理
    {
        [Required]
        public string 銀行名稱 { get; set; }
        [Required]
        public int 銀行代碼 { get; set; }
        [MaxLength(3)]
        public Nullable<int> 分行代碼 { get; set; }
        [Required]
        public string 帳戶名稱 { get; set; }
        [Required]
        public string 帳戶號碼 { get; set; }
    }
}