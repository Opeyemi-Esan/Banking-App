namespace BankingAppWebApi.Models
{
    public class TransactionDTO
    {
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string TransactionFrom { get; set; }
        public string TransactionTo { get; set; }
        public string TransactionDescription { get; set; }
    }
}
