using MVC5homework1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5homework1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        CustomerEntities db = new CustomerEntities();
        // GET: 客戶資料
        public ActionResult Index(string search)
        {
            var data = db.客戶資料.Take(50).Where(x => x.是否已刪除 == false);
            
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.客戶名稱.Contains(search));
            }

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(客戶資料 customer)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(db.客戶資料.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id , 客戶資料 customer )
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶資料.Find(id);
                item.客戶名稱 = customer.客戶名稱;
                item.統一編號 = customer.統一編號;
                item.電話 = customer.電話;
                item.傳真 = customer.傳真;
                item.地址 = customer.地址;
                item.Email = customer.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(db.客戶資料.Find(id));
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = db.客戶資料.Find(id);
                    item.是否已刪除 = true;

                    var d = db.客戶聯絡人.Where(x => x.客戶Id == id).FirstOrDefault();
                    d.是否已刪除 = true;

                    var b = db.客戶銀行資訊.Where(x => x.客戶Id == id).FirstOrDefault();
                    b.是否已刪除 = true;

                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex )
                {

                    throw ex;
                }
    
            }
            return RedirectToAction("Index");
        }
    }
}