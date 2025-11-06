using ProductManagementApi.Models;
using ProductManagementApi.Repositories.Interfaces;
using ProductManagementApi.Services.Interfaces;

namespace ProductManagementApi.Services;

public class ProductService : IProductService
{
   private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
        
            await _repo.GetAllAsync();

        public async Task<Product?> GetProductByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Product> CreateProductAsync(Product product) =>
            await _repo.AddAsync(product);

        public async Task<Product?> UpdateProductAsync(Product product) =>
            await _repo.UpdateAsync(product);

        public async Task<bool> DeleteProductAsync(int id) =>
            await _repo.DeleteAsync(id);
    }