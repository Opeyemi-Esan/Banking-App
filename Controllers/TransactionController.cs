using BankingAppWebApi.Models;
using BankingAppWebApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> CreateTransaction(TransactionDTO transactionDTO)
        {
            var createTransaction = await _transactionService.CreateTransaction(transactionDTO);
            return Ok(createTransaction);
        }

        [HttpGet("get-all-transaction")]
        public async Task<IActionResult> GetTransaction()
        {
            var response = await _transactionService.GetTransaction();
            return Ok(response);

        }
    }
}
