﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5homework1.Models;
using System.Net;

namespace MVC5homework1.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        CustomerEntities db = new CustomerEntities();
        // GET: 客戶聯絡人
        public ActionResult Index(string search)
        {
            var data = db.客戶聯絡人.Take(50).Where(x => x.是否已刪除 == false); ;
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.姓名.Contains(search));
            }

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int? 客戶id ,客戶聯絡人 customer)
        {
            if (客戶id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.客戶聯絡人.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int? id , int 客戶id,客戶聯絡人 customer)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                var item = db.客戶聯絡人.Find(id);
                item.姓名 = customer.姓名;
                item.手機 = customer.手機;
                item.電話 = customer.電話;
                item.職稱 = customer.職稱;
                item.Email = customer.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(db.客戶聯絡人.Find(id));
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶聯絡人.Find(id);
                item.是否已刪除 = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}