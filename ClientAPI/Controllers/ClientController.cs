using ClientAPI.Data;
using ClientAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientMD>>> GetClient()
        {
            return Ok(await _context.ClientMDs.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ClientMD>>> CreateClients(ClientMD client)
        {
            _context.ClientMDs.Add(client);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClientMDs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ClientMD>>> UpdateClients(ClientMD client)
        {
            var dbClient = await _context.ClientMDs.FindAsync(client.Id);
            if (dbClient == null) { return BadRequest("Client not Found"); }

            dbClient.FirstName = client.FirstName;
            dbClient.LastName = client.LastName;
            dbClient.Place = client.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.ClientMDs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ClientMD>>> DeleteClients(int id)
        {
            var dbClient = await _context.ClientMDs.FindAsync(id);
            if (dbClient == null) { return BadRequest("Client not Found"); }

            _context.ClientMDs.Remove(dbClient);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClientMDs.ToListAsync());
        }
    }
}
