
using cyptowallet.DTOs;
using cyptowallet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cyptowallet.Controllers;

[Route("api/Clients")]
[ApiController]

public class ClientController : ControllerBase
{
    private readonly ContexDb _context;

    public ClientController(ContexDb context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient(NewClientDTO newClient)
    {
        var client = new Client
        {
            Name = newClient.Name,
            Email = newClient.Email,
        };
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = client }, client);
    }



    [HttpGet]
    public async Task<ActionResult<List<ClientDTO>>> Get()
    {
        var clients = await _context.Clients
            .ToListAsync();
        var clientDtos = clients.Select(client => new ClientDTO
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
        }).ToList();
        return Ok(clientDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> Get(int id)
    {
        var clients = await _context.Clients.Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        if (clients == null)
            return NotFound("Cliente no encontrado");

        var dto = new ClientDTO
        {
            Id = clients.Id,
            Name = clients.Name,
            Email = clients.Email,
        };
        return Ok(dto);
    }
}
