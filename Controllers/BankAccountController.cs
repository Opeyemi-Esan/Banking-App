using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost("create-bankdefault-account")]
        public async Task<IActionResult> CreateAccount(BankAccountOpeningDTO bankAccountOpeningDTO)
        {
            var createAccount = await _bankAccountService.CreateAccount(bankAccountOpeningDTO);
            return Ok(createAccount);
        }

        [HttpPost("credit-customer-account")]
        public async Task<IActionResult> CreditAccounts(BankAccountDTO bankAccountDTO)
        {
            var creditCustomer = await _bankAccountService.CreditAccounts(bankAccountDTO);
            return Ok(creditCustomer);
        }

        [HttpGet("get-bank-account")]
        public async Task<IActionResult> GetBalance()
        {
            var response = await _bankAccountService.GetBalance();
            return Ok(response);
        }
    }
}
