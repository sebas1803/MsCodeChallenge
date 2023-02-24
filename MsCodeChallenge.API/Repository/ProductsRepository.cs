using MsCodeChallenge.API.Context;
using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.API.Repository {
    public class ProductsRepository : IProductsRepository {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task InsertProduct(Product product) {
            await _context.Product.AddAsync(product);
        }
        public async Task<Product> FindProductById(int id) {
            return await _context.Product.FindAsync(id);
        }
        public void UpdateProduct(Product product) {
             _context.Product.Update(product);
        }
    }
}
