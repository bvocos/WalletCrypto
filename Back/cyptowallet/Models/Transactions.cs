using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cyptowallet.Models
{
    public class Transactions
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public decimal CryptoAmount { get; set; }
        [Required]
        public decimal Money { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        
        public bool IsDelete { get; set; }=false;
        [Required]
        public int TypeTransactionId  { get; set; }
        [ForeignKey("TypeTransaction")]
        public TypeTransaction TransactionType { get; set; }

        [Required]
        public int CryptoId     { get; set; }


        [ForeignKey("CyptoId")]
        public Crypto Crypto { get; set; }

        [Required]
        public int ClientId     { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
