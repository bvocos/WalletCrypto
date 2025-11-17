using System.ComponentModel.DataAnnotations;

namespace cyptowallet.Models
{
    public class TypeTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}
