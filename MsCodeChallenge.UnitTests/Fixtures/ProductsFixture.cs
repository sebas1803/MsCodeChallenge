using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.UnitTests.Fixtures {
    public static class ProductsFixture {
        public static Product GetTestProduct() => new() {
            ProductId = 1,
            Name = "Test product",
            Status = new Status() {
                StatusKey = 1,
                StatusName = "Active",
            },
            Stock = 30,
            Description = "El mejor producto",
            Price = 1,
            Discount = 44,
            FinalPrice = 16.8,
        };
    }
}
