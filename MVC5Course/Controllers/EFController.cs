﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            var data = db.Product.AsQueryable()
                                 .Where(a => a.Active == true && a.Is刪除 == false)
                                 .Take(20)
                                 .OrderByDescending(p => p.ProductId);
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {

            return View(db.Product.Find(id));
        }
        public ActionResult Edit(int id)
        {
            
            return View(db.Product.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id , Product Product)
        {
            if (ModelState.IsValid)
            {
                var item = db.Product.Find(id);
                item.ProductName = Product.ProductName;
                item.Price = Product.Price;
                item.Stock = Product.Stock;
                item.Active = Product.Active;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }
        public ActionResult Delete(int id)
        {
            return View(db.Product.Find(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteOK(int id)
        {
            ////FK先刪 導覽屬性OrderLine
            //db.OrderLine.RemoveRange(db.Product.Find(id).OrderLine);
            //db.Product.Remove(db.Product.Find(id));
            var item = db.Product.Find(id);
            item.Is刪除 = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}