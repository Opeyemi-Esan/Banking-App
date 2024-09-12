using BankingAppWebApi.Models;

namespace BankingAppWebApi.Services.Interface
{
    public interface IAccountService
    {
        //Task<string> CreateAccount(AccountOpeningDTO accountOpeningDTO);
        Task<List<Account>> GetAllAccounts();
        Task<Account> RetreiveAccount(Guid id);
        Task<string> DeleteAccount(Guid id);
        Task<Account> GetCustomerById(Guid id);
    }
}
