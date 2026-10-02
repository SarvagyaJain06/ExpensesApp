using Expenses.API.Data;
using Expenses.API.Data.Services;
using Expenses.API.Dtos;
using Expenses.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var allTransactions = _transactionService.GetAll();
            return Ok(allTransactions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            var transaction = _transactionService.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        [HttpGet("Query")]
        public IActionResult GetNew(int id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] PostTransactionDto payload)
        {
            var transaction = _transactionService.Add(payload);
            return Ok(transaction);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id,[FromBody] PutTransactionDto payload) 
        {
            var updateTransaction = _transactionService.Update(id, payload);
            if (updateTransaction == null)
            {
                return NotFound();
            }
            return Ok(updateTransaction);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
             _transactionService.Delete(id);
            return Ok();
        }
        
    }
}
