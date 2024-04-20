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
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, DataContext>, ICategoryDal
    {
        public override List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            using (var context = new DataContext())
            {
                var categories = context.Categories.Include(i => i.Products).AsQueryable();

                return filter == null
                    ? categories.ToList()
                    : categories.Where(filter).ToList();
            }
        }
    }
}
