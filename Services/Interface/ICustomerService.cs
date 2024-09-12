using BankingAppWebApi.Models;

namespace BankingAppWebApi.Services.Interface
{
    public interface ICustomerService
    {
        Task<string> Register(AccountOpeningDTO accountOpeningDTO);
        Task<Customer> Login(LoginDTO loginDTO);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByEmail(string email);
        Task<string> DeleteCustomerAccount(Guid id, string password);
        Task<string> ChangePassword(Guid id, string password, string newPassword);
    }
}
