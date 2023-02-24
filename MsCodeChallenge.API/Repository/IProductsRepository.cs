using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.API.Repository {
    public interface IProductsRepository {
        Task InsertProduct(Product product);
        Task<Product> FindProductById(int id);
        void UpdateProduct(Product product);
    }
}
