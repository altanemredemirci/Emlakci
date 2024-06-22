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
    public class EfCoreProductDetailsDal : EfCoreGenericRepository<ProductDetails, DataContext>,IProductDetailsDal
    {
        public override ProductDetails GetById(int id)
        {
            using (var context = new DataContext())
            {
                return context.ProductDetails.Where(i => i.ProductId == id).Include(i => i.Product.Category).Include(i => i.Product.City).Include(i => i.Product.Agency).Include("Images").FirstOrDefault();
            }
        }

        public override void Update(ProductDetails entity)
        {
            using (var context = new DataContext())
            {
                var product = context.Products.FirstOrDefault(i => i.Id == entity.ProductId);

                product.IsFavorite = entity.Product.IsFavorite;
                product.Address = entity.Product.Address;
                product.CoverImage = entity.Product.CoverImage;
                product.AgencyId = entity.Product.AgencyId;
                product.CityId = entity.Product.CityId;
                product.District = entity.Product.District;
                product.Type = entity.Product.Type;
                product.Price = entity.Product.Price;
                product.Title = entity.Product.Title;
                product.Status = entity.Product.Status;
                product.CategoryId = entity.Product.CategoryId;

                entity.Product = product;

                var images = context.Images.Where(i => i.ProductDetailsId == entity.Id).ToList();

                context.Images.RemoveRange(images);
                context.Images.AddRange(entity.Images);
               
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
