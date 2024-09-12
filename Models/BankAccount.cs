namespace BankingAppWebApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}
