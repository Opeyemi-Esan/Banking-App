using BankingAppWebApi.Data;
using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Services.Implementation
{
    public class BankAccountService : IBankAccountService
    {
        private readonly AppDbContext _appDbContext;
        public BankAccountService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> CreateAccount(BankAccountOpeningDTO bankAccountOpeningDTO)
        {
            await _appDbContext.BankAccounts.FirstOrDefaultAsync();

            var bank = new BankAccount
            {
                BankName = bankAccountOpeningDTO.BankName,
                Password = bankAccountOpeningDTO.Password,
                Balance = 1000000000,
                AccountNumber = GenerateAccountNumber(),
                LastUpdated = DateTime.UtcNow
            };
            await _appDbContext.BankAccounts.AddAsync(bank);
            await _appDbContext.SaveChangesAsync();
            return "Account created Successfully";
        }

        public async Task<string> CreditAccounts(BankAccountDTO bankAccountDTO)
        {
            var bankAccount = await _appDbContext.BankAccounts.FirstOrDefaultAsync(x => x.AccountNumber == bankAccountDTO.DebitAccountNumber);

            if (bankAccount == null)
            {
                return "Bank Account number cannot be null, check yourself";
            }

            if(bankAccount.Balance < bankAccountDTO.Amount)
            {
                return "Insuficient banlance";
            }
            var customerAccount = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == bankAccountDTO.CreditAccountNumber);
            if (customerAccount == null)
            {
                return "Account not found";
            }

            bankAccount.Balance -= bankAccountDTO.Amount;
            customerAccount.Balance += bankAccountDTO.Amount;
            await _appDbContext.SaveChangesAsync();
            return "Account credited succefully";
        }

        public async Task<BankAccount> GetBalance()
        {
            var response = await _appDbContext.BankAccounts.FirstOrDefaultAsync();
            return response;
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return "00" + random.Next(10000000, 99999999).ToString();
        }
    }
}
