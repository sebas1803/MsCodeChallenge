using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Services;

namespace MsCodeChallenge.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase {
    private readonly IProductsService _productsService;
    //private readonly IMemoryCache _cache;


    public ProductsController(IProductsService productsService) {
        _productsService = productsService;
        //_cache = memoryCache;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id) {
        var product = await _productsService.GetProductById(id);
        if (product.Equals(null)) {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<CreatedResult> CreateProduct([FromBody] Product product) { //Implementar CreateProductResource al body
        var createdProduct = await _productsService.CreateProduct(product);
        return Created("Product created", createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product) { //Implementar UpdateProductResource al body
        var updatedProduct = await _productsService.UpdateProduct(id, product);
        return Ok(updatedProduct);
    }
}

