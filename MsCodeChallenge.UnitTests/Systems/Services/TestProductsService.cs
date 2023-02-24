using FluentAssertions;
using Moq;
using Moq.Protected;
using MsCodeChallenge.API.Models;
using MsCodeChallenge.API.Services;
using MsCodeChallenge.UnitTests.Fixtures;
using MsCodeChallenge.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsCodeChallenge.UnitTests.Systems.Services {
    public class TestProductsService {
        [Fact]
        public async Task GetProductById_WhenCalled_InvokesHttpGetRequest() {
            //Arrange
            var expectedResponse = ProductsFixture.GetTestProduct();
            var handlerMock = MockHttpMessageHandler<Product>.SetupBasicGetResource(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new ProductsService(httpClient);

            //Act
            await sut.GetProductById(1);

            //Assert
            handlerMock
                .Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
                );
        }
        [Fact]
        public async Task GetProductById_WhenCalled_ReturnsProduct() {
            //Arrange
            var expectedResponse = ProductsFixture.GetTestProduct();
            var handlerMock = MockHttpMessageHandler<Product>.SetupBasicGetResource(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new ProductsService(httpClient);

            //Act
            var result = await sut.GetProductById(1);

            //Assert
            result.Should().BeOfType<Product>();
        }
    }
}
