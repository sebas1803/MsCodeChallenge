using Microsoft.AspNetCore.Mvc;
using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Models.Resources;
using MsCodeChallenge.API.Repository;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using System.Text.Json;

namespace MsCodeChallenge.API.Services {
    public class ProductsService : IProductsService {
        private readonly HttpClient _httpClient;
        private readonly IProductsRepository _productRepository;
        public ProductsService(HttpClient httpClient, IProductsRepository productRepository) {
            _httpClient = httpClient;
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(CreateProduct createProduct) {
            try {
                Product product = new Product();
                product.Name = createProduct.Name;
                product.Status.StatusKey = createProduct.Status;
                product.Stock = createProduct.Stock;
                product.Description = createProduct.Description;
                product.Price = createProduct.Price;

                HttpResponseMessage discountResponse = await _httpClient.GetAsync($"https://63f6d7ca59c944921f7a200f.mockapi.io/api/v1/discounts/{createProduct.ProductId}");
                if (discountResponse.IsSuccessStatusCode) {
                    var discount = await discountResponse.Content.ReadAsStringAsync();
                    var dynamicObject = JsonConvert.DeserializeObject<dynamic>(discount)!;
                    product.Discount = dynamicObject.quantity;

                    var finalPrice = createProduct.Price * (100 - dynamicObject.quantity) / 100;
                    product.FinalPrice = finalPrice;
                }
                await _productRepository.InsertProduct(product);
                return product;
            }
            catch (Exception e) {
                throw;
            }
        }

        public async Task<Product> GetProductById(int id) {
            var product = await _productRepository.FindProductById(id);
            return product;
        }

        public async Task<Product> UpdateProduct(int id, UpdateProduct product) {
            var existingProduct = await _productRepository.FindProductById(id);
            if (existingProduct == null) {
                return null;
            }

            try {
                HttpResponseMessage discountResponse = await _httpClient.GetAsync($"https://63f6d7ca59c944921f7a200f.mockapi.io/api/v1/discounts/{id}");

                existingProduct.Name = product.Name;
                existingProduct.Status.StatusKey = product.Status;
                existingProduct.Stock = product.Stock;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                if (discountResponse.IsSuccessStatusCode) {
                    var discount = await discountResponse.Content.ReadAsStringAsync();
                    var dynamicObject = JsonConvert.DeserializeObject<dynamic>(discount)!;
                    existingProduct.Discount = dynamicObject.quantity;

                    var finalPrice = product.Price * (100 - dynamicObject.quantity) / 100;
                    existingProduct.FinalPrice = finalPrice;
                }

                _productRepository.UpdateProduct(existingProduct);
                return existingProduct;
            }
            catch (Exception e) {
                throw;
            }
        }
    }
}
