using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.API.DTOs.Create;
using SistemaInventario.API.DTOs.Update;
using SistemaInventario.Data;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionEquiposController: ControllerBase
    {
        private readonly InventarioDbContext _context;
        public AsignacionEquiposController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asignaciones = await _context.AsignacionEquipos.ToListAsync();
            return Ok(asignaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asignaciones = await _context.AsignacionEquipos.FindAsync(id);
            if (asignaciones == null) return NotFound($"Asignación de equipo con ID {id} no existe.");
            return Ok(asignaciones);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsignacionEquiposCreateDto dto)
        {
            var asignacion = new AsignacionEquipos
            {
                EquipoId = dto.EquipoId,
                UserId = dto.UsuarioId,
                FechaAsignacion = dto.FechaAsignacion,
                Observaciones = dto.Observaciones
            };
            _context.AsignacionEquipos.Add(asignacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = asignacion.AsignacionId }, asignacion);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AsignacionEquiposUpdateDto dto)
        {
            var asignaciones = await _context.AsignacionEquipos.FindAsync(id);
            if (asignaciones == null) return NotFound($"Asignación de equipo con ID {id} no existe.");
            bool seModificoAlgo = false;
            if(!string .IsNullOrWhiteSpace(dto.Observaciones))
            {
                asignaciones.Observaciones = dto.Observaciones;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(asignaciones);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var asignaciones = await _context.AsignacionEquipos.FindAsync(id);
            if (asignaciones == null) return NotFound($"Asignación de equipo con ID {id} no existe.");
            _context.AsignacionEquipos.Remove(asignaciones);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
