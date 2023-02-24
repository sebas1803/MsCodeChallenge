namespace MsCodeChallenge.API.Models.Resources {
    public class CreateProduct: Product {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
