using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountOpeningDTO accountOpeningDTO)
        {
            var register = await _customerService.Register(accountOpeningDTO);
            return Ok(register);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var customer = await _customerService.Login(loginDTO);
            return Ok(customer);
        }

        [HttpGet("get-customer-byId/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var response = await _customerService.GetCustomerById(id);
            return Ok(response);
        }

        [HttpGet("get-customer-byemail/{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var response = await _customerService.GetCustomerByEmail(email);
            return Ok(response);
        }

        [HttpGet("get-allCustomer")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customerService.GetAllCustomers();
            return Ok(response);
        }

        [HttpDelete("delete-customer/{id}")]
        public void DeleteCustomerAccount(Guid id, string password)
        {
            var customer = _customerService.DeleteCustomerAccount(id, password);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, string password, string newPassword)
        {
            var currentPassword = await _customerService.ChangePassword(id, password, newPassword);
            return Ok(currentPassword);
        }
    }
}
