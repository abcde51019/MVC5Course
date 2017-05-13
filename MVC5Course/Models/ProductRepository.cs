using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public override IQueryable<Product> All()
        {
            return base.All().Where(x => !x.Is刪除);  
        }
        public IQueryable<Product> All(bool showAll)
        {
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }
        public Product Get單筆資料ByProductId(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get全部資料(bool showAll, bool Active = false)
        {
           var ShowAll = this.All(showAll);
           return ShowAll.Where(x => x.Active == Active).Take(20);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}