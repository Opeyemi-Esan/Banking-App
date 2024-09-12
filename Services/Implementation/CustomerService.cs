using BankingAppWebApi.Data;
using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _appDbContext;
        public CustomerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> ChangePassword(Guid id, string password, string newPassword)
        {
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null) 
            {
                return null;
            }
            if(customer.HashedPassword == password)
            {
                customer.HashedPassword = newPassword;
                await _appDbContext.SaveChangesAsync();
            }
            return "Password Changed successfully";
        }

        public async Task<string> DeleteCustomerAccount(Guid id, string password)
        {
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
               
            }
            if(customer.HashedPassword == password)
            {
                _appDbContext.Customers.Remove(customer);
                await _appDbContext.SaveChangesAsync();
            }
            return "Customer deleted successfully";
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var allcustomer = await _appDbContext.Customers.ToListAsync();
            return allcustomer;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var customerByEmail = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Email == email);
            if (customerByEmail == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            return customerByEmail;
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var customerById = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerById == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            return customerById;
        }

        public async Task<Customer> Login(LoginDTO loginDTO)
        {
            
            var user = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);
            if (user is not null)
            {
                var isCorrectPassword = PasswordHelper.VerifyPassword(loginDTO.Password, user.HashedPassword);
                if (isCorrectPassword)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<string> Register(AccountOpeningDTO accountOpeningDTO)
        {
            var emailExist = await _appDbContext.Customers.AnyAsync(e => e.Email == accountOpeningDTO.Email);
            if (emailExist) 
            {
                throw new InvalidOperationException("Email already in exist.");
            }
            if(accountOpeningDTO.Password != accountOpeningDTO.ConfirmPassword)
            {
                throw new InvalidOperationException("Password not match");
            }

            var customer = new Customer
            {
                FirstName = accountOpeningDTO.FirstName,
                LastName = accountOpeningDTO.LastName,
                Email = accountOpeningDTO.Email,
                PhoneNumber = accountOpeningDTO.Phone,
                DateOfBirth = accountOpeningDTO.DateOfBirth,
                AddressLine = accountOpeningDTO.AddressLine,
                Country = accountOpeningDTO.Country,
                NextOfKin = accountOpeningDTO.NextOfKin,
                NextOfKinPhone = accountOpeningDTO.NextOfKinPhone,
                CreationDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            };

            var (hashedPassword, salt) = PasswordHelper.HashPassword(accountOpeningDTO.Password);
            customer.HashedPassword = hashedPassword;

            await _appDbContext.Customers.AddAsync(customer);

            var account = new Account
            {
                CustomerId = customer.Id,
                AccountNumber = GenerateAccountNumber(),
                Balance = 0,
                CreationDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
                AccountType = accountOpeningDTO.AccountType,

            };
            await _appDbContext.Accounts.AddAsync(account);
            await _appDbContext.SaveChangesAsync();
            return "Congratulation! Customer registered successfully";
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return "00" + random.Next(10000000, 99999999).ToString();
        }
    }
}
