using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreProductDal
    {
        private DataContext dataContext = new DataContext();

        public void Insert(Product product)
        {
            dataContext.Products.Add(product);
            dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var p = dataContext.Products.Find(id);
            dataContext.Products.Remove(p);
            dataContext.SaveChanges();
        }
        public void Update(Product product)
        {
            dataContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
           return  dataContext.Products.ToList();
        }
        public Product GetById(int id)
        {
            return dataContext.Products.Find(id);
        }
        public Product GetOne(Expression<Func<Product,bool>> filter)
        {
            return dataContext.Products.Where(filter).FirstOrDefault();
        }

    }
}
