using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);

    }
}
