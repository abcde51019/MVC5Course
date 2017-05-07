using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ValidateAttribute
{
    public class 商品名稱需包含LIN字元Attribute : DataTypeAttribute
    {
        public 商品名稱需包含LIN字元Attribute() : base (DataType.Text)
        {
            ErrorMessage = "商品名稱需包含LIN字元";
        }
        public override bool IsValid(object value)
        {
            var str = (string)value;
            return str.Contains("LIN"); 
        }
    }
}