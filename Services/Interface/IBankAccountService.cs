using BankingAppWebApi.Models;

namespace BankingAppWebApi.Services.Interface
{
    public interface IBankAccountService
    {
        Task<string> CreateAccount(BankAccountOpeningDTO bankAccountOpeningDTO);
        Task<string> CreditAccounts(BankAccountDTO bankAccountDTO);
        Task<BankAccount> GetBalance();
    }
}
