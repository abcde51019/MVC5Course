using MVC5homework1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5homework1.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        CustomerEntities db = new CustomerEntities();
        // GET: 客戶銀行資訊
        public ActionResult Index(string search)
        {
            var data = db.客戶銀行資訊.Take(50).Where(x => x.是否已刪除 == false); ;
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.帳戶名稱.Contains(search));
            }

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int? 客戶id, 客戶銀行資訊 customer)
        {
            if (客戶id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.客戶銀行資訊.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.客戶銀行資訊.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int? id, int 客戶id, 客戶銀行資訊 customer)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                var item = db.客戶銀行資訊.Find(id);
                item.分行代碼 = customer.分行代碼;
                item.銀行代碼 = customer.銀行代碼;
                item.銀行名稱 = customer.銀行名稱;
                item.帳戶號碼 = customer.帳戶號碼;
                item.帳戶名稱 = customer.帳戶名稱;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(db.客戶銀行資訊.Find(id));
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶銀行資訊.Find(id);
                item.是否已刪除 = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}