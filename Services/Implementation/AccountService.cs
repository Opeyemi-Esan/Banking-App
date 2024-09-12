using BankingAppWebApi.Data;
using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BankingAppWebApi.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _appDbContext;
        public AccountService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //public async Task<string> CreateAccount(AccountOpeningDTO accountOpeningDTO)
        //{
        //    var account = new Account
        //    {
                
        //    };

        //    _appDbContext.Accounts.Add(account);
        //    await _appDbContext.SaveChangesAsync();
        //    return "Congratulation! Your was created successfully";
        //}
        

        public async Task<string> DeleteAccount(Guid id)
        {
            var account = _appDbContext.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null) 
            {
                return "Account not registered with us";
            }
            _appDbContext.Accounts.Remove(account);
            await _appDbContext.SaveChangesAsync();
            return "Account deleted successfully";
        }

        public async Task<Account> RetreiveAccount(Guid id)
        {
            var account = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if(account == null)
            {
                return null;
            }
            return account;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var response = await _appDbContext.Accounts.ToListAsync();
            return response;
        }

        public async Task<Account> GetCustomerById(Guid id)
        {
            var response = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
