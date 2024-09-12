using System.ComponentModel.DataAnnotations;

namespace BankingAppWebApi.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Customer Customer { get; set; }
        public AccountType AccountType { get; set; }
    }
    
}
