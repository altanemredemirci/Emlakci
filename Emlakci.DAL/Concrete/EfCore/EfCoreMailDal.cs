using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreMailDal : EfCoreGenericRepository<Mail, DataContext>, IMailDal
    {
        public List<Mail> GetLast4Mail()
        {
            using(var context = new DataContext())
            {
                return context.Mails.Where(i=> i.IsRead==false).OrderByDescending(i => i.Id).Take(4).ToList();
            }
        }
    }
}
