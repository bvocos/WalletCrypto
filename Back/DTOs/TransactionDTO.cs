using cyptowallet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cyptowallet.DTOs
{
    public class TransactionDTO
    {
        public string Id { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal Money { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDelete { get; set; } = false;
        public TypeTransactionDTO TransactionType { get; set; }
        public CryptoDTO Crypto { get; set; }
        public ClientDTO Client { get; set; }
    }
}
