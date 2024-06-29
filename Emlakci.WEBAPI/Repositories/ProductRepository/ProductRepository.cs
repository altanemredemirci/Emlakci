using Emlakci.Entity;
using Emlakci.WEBAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Emlakci.WEBAPI.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EstateContext _estateContext;

        public ProductRepository(EstateContext estateContext)
        {
            _estateContext = estateContext;
        }

        public async Task<int> CreateProductAsync(ProductDetails productDetails)
        {
            await _estateContext.ProductDetails.AddAsync(productDetails);

            return await _estateContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var model = _estateContext.Products.Find(id);
            _estateContext.Products.Remove(model);


            return await _estateContext.SaveChangesAsync();

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _estateContext.Products.ToListAsync();
        }

        public async Task<ProductDetails> GetByIdAsync(int id)
        {
            var value = await _estateContext.ProductDetails.Where(i => i.ProductId == id).Include(i => i.Product).ThenInclude(i => i.Category).Include(i => i.Product.City).Include(i => i.Product.Agency).Include(i => i.Images).FirstOrDefaultAsync();

            return value;
        }

        public Task<int> UpdateProductAsync(ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }
    }
}
