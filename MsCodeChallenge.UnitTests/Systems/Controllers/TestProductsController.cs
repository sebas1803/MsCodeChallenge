using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Services;
using MsCodeChallenge.UnitTests.Fixtures;

namespace MsCodeChallenge.UnitTests.Systems.Controllers;

public class TestProductsController {

    //GET TEST METHODS
    [Fact]
    public async Task GetProductById_ReturnsProduct_StatusCode_200() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        mockProductsService
            .Setup(service => service.GetProductById(1))
            .ReturnsAsync(ProductsFixture.GetTestProduct());

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = (OkObjectResult)await sut.GetProductById(1);

        //Assert
        result.Should().BeOfType<OkObjectResult>();;
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeOfType<Product>();
        
    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_StatusCode_404() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        mockProductsService
            .Setup(service => service.GetProductById(1))
            .ReturnsAsync(new Product());

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = await sut.GetProductById(1);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetProductById_OnSuccess_InvokesOnce() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        mockProductsService
            .Setup(service => service.GetProductById(1))
            .ReturnsAsync(new Product());

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = await sut.GetProductById(1);

        //Assert
        mockProductsService.Verify(service => service.GetProductById(1),
            Times.Once());
    }

    //POST TEST METHODS
    [Fact]
    public async Task CreateProduct_ReturnsStatusCode_201() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        var product = new Product();
        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = await sut.CreateProduct(product);

        //Assert
        result.StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task CreateProduct_OnSuccess_CreatesProductOnce() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        var product = new Product();
        mockProductsService
            .Setup(service => service.CreateProduct(product))
            .ReturnsAsync(product);

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = await sut.CreateProduct(product);

        //Assert
        mockProductsService.Verify(service => service.CreateProduct(product),
            Times.Once());
    }

    //PUT TEST METHODS
    [Fact]
    public async Task UpdateProduct_ReturnsStatusCode_200() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        var product = new Product();
        mockProductsService
            .Setup(service => service.UpdateProduct(1, product))
            .ReturnsAsync(product);

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = (OkObjectResult)await sut.UpdateProduct(1, product);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task UpdateProduct_OnSuccess_UpdatesProductOnce() {
        //Arrange
        var mockProductsService = new Mock<IProductsService>();
        var product = new Product();
        mockProductsService
            .Setup(service => service.UpdateProduct(1, product))
            .ReturnsAsync(product);

        var sut = new ProductsController(mockProductsService.Object);

        //Act
        var result = await sut.UpdateProduct(1, product);

        //Assert
        mockProductsService.Verify(service => service.UpdateProduct(1, product),
            Times.Once());
    }
}