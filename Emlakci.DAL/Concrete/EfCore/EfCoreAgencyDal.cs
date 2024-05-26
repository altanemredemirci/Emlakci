using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreAgencyDal : EfCoreGenericRepository<Agency, DataContext>, IAgencyDal
    {
        public override Agency GetById(int id)
        {
            using(var context = new DataContext())
            {
                return context.Agencies.Include(i => i.Products).ThenInclude(i=> i.Category).Include(i=>i.Products).ThenInclude(i=> i.City).Include(i=> i.Products).ThenInclude(i=>i.ProductDetails).FirstOrDefault(i => i.Id == id);
            }
        }
    }
}
