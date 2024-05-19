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
    public class EfCoreWhoWeAreDal : IWhoWeAreDal
    {
        public WhoWeAre GetById(int id)
        {
            using (var context = new DataContext())
            {
                return context.WhoWeAres.Find(id);
            }
        }

        public WhoWeAre GetFirst()
        {
            using (var context = new DataContext())
            {
                return context.WhoWeAres.FirstOrDefault();
            }
        }

        public void Update(WhoWeAre entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
