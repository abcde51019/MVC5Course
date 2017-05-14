using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC5Course.Controllers
{
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public abstract class BaseController: Controller
    {
      
        protected FabricsEntities db = new FabricsEntities();
        public ActionResult Debug()
        {
            return Content("hello~");
        }
        protected override void HandleUnknownAction(string actionName)
        {
            //偵測不到的action 強制轉回首頁
            //this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
            
        }
    }

}