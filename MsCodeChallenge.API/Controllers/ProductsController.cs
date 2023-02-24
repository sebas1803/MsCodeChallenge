using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Models.Resources;
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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById(int id) {
        var product = await _productsService.GetProductById(id);
        if (product == null) {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<CreatedResult> CreateProduct([FromBody] CreateProduct product) {
        var createdProduct = await _productsService.CreateProduct(product);
        return Created("Product created", createdProduct);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProduct product) {
        var updatedProduct = await _productsService.UpdateProduct(id, product);
        if (updatedProduct == null) {
            return NotFound();
        }
        return Ok(updatedProduct);
    }
}

