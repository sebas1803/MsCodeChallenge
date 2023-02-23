using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.API.Services {
    public interface IProductsService {
        public Task<Product> CreateProduct(Product product);
        public Task<Product> GetProductById(int id);
        public Task<Product> UpdateProduct(int id, Product product);
    }
}
