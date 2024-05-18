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
    public class ProductDetailManager : IProductDetailService
    {
        private readonly IProductDetailsDal _productDetailsDal;

        public ProductDetailManager(IProductDetailsDal productDetailsDal)
        {
            _productDetailsDal = productDetailsDal;
        }

        public void Create(ProductDetails entity)
        {
            _productDetailsDal.Create(entity);
        }

        public void Delete(ProductDetails entity)
        {
            _productDetailsDal.Delete(entity);
        }

        public List<ProductDetails> GetAll(Expression<Func<ProductDetails, bool>> filter = null)
        {
            return _productDetailsDal.GetAll(filter);
        }

        public ProductDetails GetById(int id)
        {
            return _productDetailsDal.GetById(id);
        }

        public void Update(ProductDetails entity)
        {
            _productDetailsDal.Update(entity);
        }
    }
}
