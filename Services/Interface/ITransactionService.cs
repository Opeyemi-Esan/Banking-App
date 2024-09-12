using BankingAppWebApi.Models;

namespace BankingAppWebApi.Services.Interface
{
    public interface ITransactionService
    {
        Task<string> CreateTransaction(TransactionDTO transactionDTO);
        Task<string> DeleteTransaction(Guid id);
        Task<List<Transaction>> GetTransaction();
        Task<Transaction> GetTransactionById(Guid id);
    }
}
