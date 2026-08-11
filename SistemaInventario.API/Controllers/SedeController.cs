using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.API.DTOs.Create;
using SistemaInventario.API.DTOs.Update;
using SistemaInventario.Data;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class SedeController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public SedeController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sede = await _context.Sedes.ToListAsync();
            return Ok(sede);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null) return NotFound($"La sede con el id {id} no existe");
            return Ok(sede);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SedeCreateDto dto)
        {
            var sede = new Sedes
            {
                NombreSede = dto.NombreSede,
                Piso = dto.Piso,
                Ciudad = dto.Ciudad
            };
            _context.Sedes.Add(sede);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sede.UbicacionId }, sede);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SedeUpdateDto dto)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null) return NotFound($"La sede con id {id} no existe");
            bool seModificoAlgo = false;
            if (!string.IsNullOrWhiteSpace(dto.NombreSede))
            {
                sede.NombreSede = dto.NombreSede.Trim();
                seModificoAlgo = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.Piso))
            {
                sede.Piso = dto.Piso.Trim();
                seModificoAlgo = true;
            }
            if (!seModificoAlgo)
            {
                return BadRequest("No se modificó ningún campo");
            }
            await _context.SaveChangesAsync();
            return Ok(sede);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null) return NotFound($"La sede con id {id} no existe");
            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
