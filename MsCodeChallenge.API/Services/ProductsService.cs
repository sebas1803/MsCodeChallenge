using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.API.Services {
    public class ProductsService : IProductsService {
        public Task<Product> CreateProduct(Product product) {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id) {
            //return await _productRepository.GetByIdAsync(id);
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(int id, Product product) {
            throw new NotImplementedException();
        }
    }
}
