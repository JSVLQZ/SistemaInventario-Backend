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
            var sedes = await _context.Sedes.ToListAsync();
            return Ok(sedes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sedes = await _context.Sedes.FindAsync(id);
            if (sedes == null) return NotFound($"La sede con el id {id} no existe");
            return Ok(sedes);
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
            var sedes = await _context.Sedes.FirstOrDefaultAsync(s => s.UbicacionId == id);
            if (sedes == null) return NotFound($"La sede con id {id} no existe");
            bool seModificoAlgo = false;
            if(!string .IsNullOrWhiteSpace(dto.NombreSede))
            {
                sedes.NombreSede = dto.NombreSede.Trim();
                seModificoAlgo = true;
            }
            if(!string .IsNullOrWhiteSpace(dto.Piso))
            {
                sedes.Piso = dto.Piso.Trim();
                seModificoAlgo = true;
            }
            if(!string .IsNullOrWhiteSpace(dto.Ciudad))
            {
                sedes.Ciudad = dto.Ciudad.Trim();
                seModificoAlgo = true;
            }
            if(seModificoAlgo)
            {
                await _context.SaveChangesAsync();
                return Ok(sedes);
            }
            return BadRequest("No se modificó ningún campo");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sedes = await _context.Sedes.FindAsync(id);
            if (sedes == null) return NotFound($"La sede con id {id} no existe");
            _context.Sedes.Remove(sedes);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
