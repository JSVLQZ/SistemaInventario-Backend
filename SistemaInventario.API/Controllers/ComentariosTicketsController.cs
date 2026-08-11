using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.API.DTOs.Helpdesk.Create;
using SistemaInventario.API.DTOs.Helpdesk.Update;
using SistemaInventario.Data;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosTicketsController:ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ComentariosTicketsController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comentarios = await _context.ComentariosTickets.ToListAsync();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comentario = await _context.ComentariosTickets.FindAsync(id);
            if (comentario == null) return NotFound($"El comentario con ID {id} no existe.");
            return Ok(comentario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComentariosTicketsCreateDto dto)
        {
            var ticketExiste = await _context.Tickets.AnyAsync(t => t.TicketId == dto.TicketId);
            if (!ticketExiste)
            {
                return NotFound($"El ticket con ID {dto.TicketId} no existe.");
            }
            var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UserId);
            if (!usuarioExiste)
            {
                return NotFound($"El usuario con ID {dto.UserId} no existe.");
            }
            var comentario = new ComentariosTickets
            {
                TicketId = dto.TicketId,
                UserId = dto.UserId,
                Mensaje = dto.Mensaje
            };
            _context.ComentariosTickets.Add(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = comentario.ComentarioId }, comentario);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComentariosTicketsUpdateDto dto)
        {
            var comentario = await _context.ComentariosTickets.FindAsync(id);
            if (comentario == null) return NotFound($"El comentario con ID {id} no existe.");
            bool seModificoAlgo = false;
            if (!string.IsNullOrWhiteSpace(dto.Mensaje))
            {
                comentario.Mensaje = dto.Mensaje;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(comentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await _context.ComentariosTickets.FindAsync(id);
            if (comentario == null) return NotFound($"El comentario con ID {id} no existe.");
            _context.ComentariosTickets.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
