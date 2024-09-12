namespace BankingAppWebApi.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransactionFrom { get; set; }
        public string TransactionTo { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public enum TransactionType
    {
        Deposit = 1,
        Transfer = 2,
        Withdrawer = 3
    }
}
