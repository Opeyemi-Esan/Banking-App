using BankingAppWebApi.Data;
using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _appDbContext;
        public TransactionService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> CreateTransaction(TransactionDTO transactionDTO)
        {
            var senderAccount = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transactionDTO.TransactionFrom);
            if (senderAccount == null)
            {
                throw new Exception("Account not found");
            }
            if(senderAccount.Balance < transactionDTO.Amount)
            {
               return ("Insuficient found");
            }
            if (transactionDTO.TransactionType == TransactionType.Transfer ) //continue the transaction if sender have more than zero naira
            {
                var beneficiary = await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transactionDTO.TransactionTo);
                if (beneficiary == null)
                {
                    return "Enter corect digits";
                }
                senderAccount.Balance -= transactionDTO.Amount;
                beneficiary.Balance = beneficiary.Balance + transactionDTO.Amount;
                await _appDbContext.SaveChangesAsync();
            }

            var transaction = new Transaction
            {
                TransactionType = transactionDTO.TransactionType,
                TransactionFrom = transactionDTO.TransactionFrom,
                TransactionTo = transactionDTO.TransactionTo,
                TransactionDescription = transactionDTO.TransactionDescription
            };
            await _appDbContext.Transactions.AddAsync(transaction);
            await _appDbContext.SaveChangesAsync();
            return "Transaction Successful";
        }

        public Task<string> DeleteTransaction(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Transaction>> GetTransaction()
        {
            var response = await _appDbContext.Transactions.ToListAsync();
            return response;
        }

        public Task<Transaction> GetTransactionById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
