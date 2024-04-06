using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, DataContext>, IProductDal
    {
        public override List<Product> GetAll(Expression<Func<Product,bool>> filter)
        {
            using(var context = new DataContext())
            {
                var products = context.Products.Include(i => i.Category).AsQueryable();

                return filter == null
                    ? products.ToList()
                    : products.Where(filter).ToList();
            }
        }
    }
}
