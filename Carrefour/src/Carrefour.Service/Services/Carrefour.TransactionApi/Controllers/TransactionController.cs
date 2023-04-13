using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.TransactionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionModel>>> GetTransactionsAsync()
    {
        var transactions = await _transactionService.GetTransactionsAsync();
        return Ok(transactions);
    }

    [HttpGet("debits")]
    public async Task<ActionResult<IEnumerable<Debit>>> GetDebitsAsync()
    {
        var debits = await _transactionService.GetDebitsAsync();
        return Ok(debits);
    }

    [HttpGet("credits")]
    public async Task<ActionResult<IEnumerable<Credit>>> GetCreditsAsync()
    {
        var credits = await _transactionService.GetCreditsAsync();
        return Ok(credits);
    }

    [HttpPost]
    public async Task<IActionResult> AddTransactionAsync([FromBody] TransactionModel transaction)
    {
        await _transactionService.AddTransactionAsync(transaction);
        return Ok();
    }
}