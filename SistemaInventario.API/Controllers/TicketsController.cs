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
    public class TicketsController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public TicketsController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null) return NotFound($"El ticket con ID {id} no existe.");
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketsCreateDto dto)
        {
            var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UserId);
            if (!usuarioExiste)
                return BadRequest($"El usuario con ID {dto.UserId} no existe.");
            var categoriaExiste = await _context.CategoriaTicket.AnyAsync(c => c.CategoriaId == dto.CategoriaId);
            if (!categoriaExiste)
                return BadRequest($"La categoría con ID {dto.CategoriaId} no existe.");
            if(dto.EquipoId.HasValue)
            {
                var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId.Value);
                if (!equipoExiste)
                    return BadRequest($"El equipo con ID {dto.EquipoId.Value} no existe.");
            }
            var tickets = new Tickets
            {
                UserId = dto.UserId,
                EquipoId = dto.EquipoId,
                CategoriaId = dto.CategoriaId,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion

            };
            _context.Tickets.Add(tickets);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tickets.TicketId }, tickets);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketsUpdateDto dto)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null) return NotFound($"El ticket con ID {id} no existe.");
            bool seModificoAlgo = false;
            if (dto.CategoriaId.HasValue && dto.CategoriaId.Value != tickets.CategoriaId)
            {
                var categoriaexiste = await _context.CategoriaTicket.AnyAsync(c => c.CategoriaId == dto.CategoriaId.Value);
                if (!categoriaexiste)
                {
                    return BadRequest($"La categoría con ID {dto.CategoriaId.Value} no existe.");
                }
                tickets.CategoriaId = dto.CategoriaId.Value;
                seModificoAlgo = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                tickets.Descripcion = dto.Descripcion;
                seModificoAlgo = true;
            }
            if (!seModificoAlgo)
            {
                return BadRequest("No se modificó ningún campo.");
            }
            await _context.SaveChangesAsync();
            return Ok(tickets);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null) return NotFound($"El ticket con ID {id} no existe.");
            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
