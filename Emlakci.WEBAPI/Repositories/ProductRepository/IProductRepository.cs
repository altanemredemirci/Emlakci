using Emlakci.Entity;

namespace Emlakci.WEBAPI.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<ProductDetails> GetByIdAsync(int id);
        Task<int> CreateProductAsync(ProductDetails productDetails);
        Task<int> UpdateProductAsync(ProductDetails productDetails);
        Task<int> DeleteProductAsync(int id);
    }
}
