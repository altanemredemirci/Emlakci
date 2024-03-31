using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {        
        public void Create(T entity)
        {
            using(var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }            
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList(); 
                //context.Products.Where(i => i.CategoryId == 1).ToList();
            }

            //using (var context = new TContext())
            //{
            //    var result = context.Set<T>().AsQueryable(); // Database kodunun bitmediğini tanımlar.

            //    if (filter != null)
            //        result = result.Where(filter);

            //    return result.ToList();
            //}
        }

        public T GetById(int id)
        {
           using(var context = new TContext())
            {
               return context.Set<T>().Find(id);
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).FirstOrDefault();
            }
        }

        public void Update(T entity)
        {
           using(var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
