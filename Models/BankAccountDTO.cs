namespace BankingAppWebApi.Models
{
    public class BankAccountDTO
    {
        public string DebitAccountNumber { get; set; }
        public string CreditAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
