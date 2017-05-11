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
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        [Required]
        public string 地址 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}