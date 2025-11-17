using cyptowallet.DTOs;
using cyptowallet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cyptowallet.Controllers;



[Route("api/Transaction")]
[ApiController]

public class TransactionsController : ControllerBase
{
    private readonly ContexDb _context;

    public TransactionsController(ContexDb context)
    {
        _context = context;
    }
    [HttpGet]

    public async Task<ActionResult<List<TransactionDTO>>> GetList([FromQuery] int? clientId)
    {
        var query = _context.Transactions.Where(X => !X.IsDelete).AsQueryable();

        if (clientId.HasValue)
            query = query.Where(X => X.ClientId == clientId);

        var transactions = await query 
            .Include(x => x.Crypto)
            .Include(x => x.TransactionType)
            .Select(x => new TransactionDTO
            {
                Id = x.Id,
                CryptoAmount = x.CryptoAmount,
                Money = x.Money,
                DateTime = x.DateTime,
                Client = new ClientDTO
                {
                    Id = x.Client.Id,
                    Name = x.Client.Name,
                    Email = x.Client.Email,

                },
                Crypto = new CryptoDTO
                {
                    id = x.Crypto.id,
                    name = x.Crypto.name,
                    code = x.Crypto.code,
                },
                TransactionType = new TypeTransactionDTO
                {
                    Id = x.TransactionType.Id,
                    Type = x.TransactionType.Type,
                }
                
            }).ToListAsync();
        return Ok(transactions);


    }


}
