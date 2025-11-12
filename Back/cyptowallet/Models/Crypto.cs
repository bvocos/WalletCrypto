using System.ComponentModel.DataAnnotations;

namespace cyptowallet.Models
{
    public class Crypto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string code { get; set; }
    }
}
