using cyptowallet.DTOs;
using cyptowallet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cyptowallet.Controllers;

[Route("api/Crypto")]
[ApiController]

public class CryptoController : ControllerBase
{
    private readonly ContexDb _context;

    public CryptoController(ContexDb context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CryptoDTO>>> getlist()
    {
        var crypto = await _context.Cryptos
            .ToListAsync();

        var cryptosDTOs = crypto.Select(cypto => new CryptoDTO
        {
            id = cypto.id,
            name = cypto.name,
            code = cypto.code,
        }).ToList();
        return (cryptosDTOs);
    }
}

