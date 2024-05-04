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
    public class EfCoreCityDal:EfCoreGenericRepository<City,DataContext>,ICityDal
    {
        public override List<City> GetAll(Expression<Func<City, bool>> filter)
        {
            using (var context = new DataContext())
            {
                var cities = context.Cities.Include(i => i.Districts).AsQueryable();

                return filter != null
                        ? cities.Where(filter).ToList()
                        : cities.ToList();
            }
        }
    }
}
