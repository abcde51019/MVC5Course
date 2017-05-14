using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
       // private FabricsEntities db = new FabricsEntities();
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: Products
        public ActionResult Index(bool? Active)
        {

            var data = repo.Get全部資料(false, Active: true);

            //var data = db.Product.OrderByDescending(x => x.ProductId)
            //             .Take(10);
            //if (Active != null)
            //{
            //    // data = data.Where(x => x.Active == true);
            //    //data = data.Where(x => x.Active.Value == Active && x.Active.HasValue);
            //}
            return View(data);
            //return View(db.Product.OrderByDescending(x => x.ProductId).Take(10).ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            //Model Binding 資料繫結
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Get單筆資料ByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        //自己定義系統例外訊息
       // [HandleError(ExceptionType = typeof(DbUpdateException), View = "Error_DbUpdateException")]
       
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            //if (ModelState.IsValid)
           // {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                //db.Product.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            //}

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.Get單筆資料ByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , FormCollection form)
        {
            //[Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product

            var product = repo.Get單筆資料ByProductId(id);

            //if (ModelState.IsValid)
            if (TryUpdateModel<Product>(product))
            {
                repo.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.Get單筆資料ByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Product.Find(id);
            //db.Product.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ProductsList(ProductListSearch Condition)
        {
            var data = repo.Get全部資料(true, Active: true);
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Condition.Search))
                {
                    data = data.Where(x => x.ProductName.Contains(Condition.Search));
                }
                data = data.Where(x => x.Stock >= Condition.StockS && 
                                       x.Stock <= Condition.StockE);
            }
            ViewData.Model = data.Select(p => new ProductList()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                Stock = p.Stock
            }).Take(30);
            return View();
            //return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductList data)
        {
            if (ModelState.IsValid)
            {
                TempData["alertResult"] = "建立成功!";
                // 儲存資料進資料庫
                return RedirectToAction("ProductsList");
            }
            //驗證失敗，繼續顯示原本的表單
            return View();
        }
    }
}
