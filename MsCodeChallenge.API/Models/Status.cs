using System.ComponentModel.DataAnnotations;

namespace MsCodeChallenge.API.Models {
    public class Status {
        [Key]
        public int Id { get; set; }
        public string StatusKey { get; set; }
        public string StatusName { get; set; }
    }
}
