using Carrefour.TransactionApi.Context;
using Carrefour.TransactionApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.TransactionApi.Controllers;

[Route("api/reports")]
public class ReportsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public ReportsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("daily-balance/{date}")]
    public IActionResult GetDailyBalance(DateTime date)
    {
        decimal initialBalance = _dbContext.Transactions
            .Where(t => t.Date < date)
            .Sum(t => t is Debit ? -t.Amount : t.Amount);

        decimal dailyDebits = _dbContext.Transactions
            .OfType<Debit>()
            .Where(t => t.Date == date)
            .Sum(t => t.Amount);

        decimal dailyCredits = _dbContext.Transactions
            .OfType<Credit>()
            .Where(t => t.Date == date)
            .Sum(t => t.Amount);

        decimal dailyBalance = initialBalance + dailyDebits + dailyCredits;

        return Ok(new
        {
            Date = date,
            InitialBalance = initialBalance,
            DailyDebits = dailyDebits,
            DailyCredits = dailyCredits,
            DailyBalance = dailyBalance
        });
    }
}
