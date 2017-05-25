using MVC5homework1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5homework1.Controllers
{
    public class 客戶清單Controller : Controller
    {
        // CustomerEntities db = new CustomerEntities();
        客戶清單Repository repo = RepositoryHelper.Get客戶清單Repository();
        // GET: 客戶清單
        public ActionResult Index()
        {
            var data = repo.All();
            // return View(db.客戶清單.Take(50));
            return View(data.Take(50));
        }
    }
}