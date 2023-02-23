using System.ComponentModel.DataAnnotations;

namespace MsCodeChallenge.API.Models {
    public class Product {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public double FinalPrice { get; set; }
    }
}
