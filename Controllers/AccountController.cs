using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpPost("create-account")]
        //public async Task<IActionResult> CreateAccount(AccountOpeningDTO accountOpeningDTO)
        //{
        //    var createAccount = await _accountService.CreateAccount(accountOpeningDTO);
        //    return Ok(createAccount);
        //}

        [HttpPost("Retrieve-account-by-id/{id}")]
        public async Task<IActionResult> RetreiveAccount(Guid id)
        {
            var response = await _accountService.RetreiveAccount(id);
            return Ok(response);
        }

        [HttpPost("GetallAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _accountService.GetAllAccounts();
            return Ok(response);
        }

        [HttpPost("Delete-account/{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var response = await _accountService.DeleteAccount(id);
            return Ok(response);
        }

        [HttpGet("get-account-by-customerid/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var response = await _accountService.GetCustomerById(id);
            return Ok(response);
        }
    }
}
