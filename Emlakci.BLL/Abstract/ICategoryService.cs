using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Abstract
{
    public interface ICategoryService:IRepositoryService<Category>
    {
        Category GetOne(Expression<Func<Category, bool>> filter = null);
    }
}
