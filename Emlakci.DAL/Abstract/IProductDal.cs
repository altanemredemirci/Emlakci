using Emlakci.DAL.Concrete.EfCore;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
       List<Product> Last4Product();        
    }
}
