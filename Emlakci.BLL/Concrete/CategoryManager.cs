using Emlakci.BLL.Abstract;
using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetOne(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetOne(filter);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
