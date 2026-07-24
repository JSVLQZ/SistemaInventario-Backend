using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.API.DTOs.Create;
using SistemaInventario.API.DTOs.Helpdesk.Create;
using SistemaInventario.API.DTOs.Helpdesk.Update;
using SistemaInventario.API.DTOs.Update;
using SistemaInventario.Data;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaTicketController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public CategoriaTicketController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoria = await _context.CategoriaTicket.ToListAsync();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _context.CategoriaTicket.FindAsync(id);
            if (categoria == null) return NotFound($"La categoría con ID {id} no existe.");
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaTicketCreateDto dto)
        {
            var categoria = new CategoriaTicket
            {
                NombreCategoria = dto.NombreCategoria
            };
            _context.CategoriaTicket.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaTicketUpdateDto dto)
        {
            var categoria = await _context.CategoriaTicket.FindAsync(id);
            if(categoria == null) return NotFound($"La categoría con ID {id} no existe.");
            bool seModificoAlgo = false;
            if (!string.IsNullOrWhiteSpace(dto.NombreCategoria))
            {
                categoria.NombreCategoria = dto.NombreCategoria;
                seModificoAlgo = true;
            }
            if(seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.CategoriaTicket.FindAsync(id);
            if (categoria == null) return NotFound($"La categoría con ID {id} no existe.");
            _context.CategoriaTicket.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
