using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        [SharedViewBagAttribute]
        [LocalOnly]
        public ActionResult PartialAbout()
        {
           // ViewBag.Message = "123123123123lkdsjf;lasjflsadjlfkj";
            if (Request.IsAjaxRequest())
            {
                return PartialView("About");
            } else
            {
                return View("About");
            }

            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return PartialView("SuccessRedirect","/");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult GetFile()
        {
            //僅顯示
            //return File(Server.MapPath("~/Content/pic.jpg"), "image/jpg");
            //會下載
            return File(Server.MapPath("~/Content/pic.jpg"), "image/jpg","pic2.jpg");
        }
        public ActionResult GetJson()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Json(db.Product.Take(5),JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewEmty()
        {
            return View();
        }
        public ActionResult RazerTest()
        {
            ViewData.Model = new int[] { 1, 2, 3, 4, 5 };
            return View();
        }
    }
}