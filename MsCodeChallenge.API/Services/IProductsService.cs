using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Models.Resources;

namespace MsCodeChallenge.API.Services {
    public interface IProductsService {
        public Task<Product> CreateProduct(CreateProduct product);
        public Task<Product> GetProductById(int id);
        public Task<Product> UpdateProduct(int id, UpdateProduct product);
    }
}
