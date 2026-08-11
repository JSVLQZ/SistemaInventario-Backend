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
    public class LicenciasSoftwareController:ControllerBase
    {
        private readonly InventarioDbContext _context;
        public LicenciasSoftwareController(InventarioDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var licencia = await _context.LicenciasSoftware.ToListAsync();
            return Ok(licencia);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var licencia = await _context.LicenciasSoftware.FindAsync(id);
            if (licencia == null) return NotFound($"Licencia de software con ID {id} no existe");
            return Ok(licencia);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LicenciasSoftwareCreateDto dto)
        {
            if (dto.EquipoId.HasValue)
            {
                var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId);
                if(!equipoExiste) return NotFound($"Equipo con ID {dto.EquipoId} no existe");
            }
            var licencia = new LicenciasSoftware
            {
                NombreLicencia = dto.NombreLicencia,
                ClaveActivacion = dto.ClaveActivacion,
                FechaExpiracion = dto.FechaExpiracion,
                TipoLicencia = dto.TipoLicencia,
                EquipoId = dto.EquipoId
            };
            _context.LicenciasSoftware.Add(licencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = licencia.LicenciaId }, licencia);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LicenciasSoftwareUpdateDto dto)
        {
            var licencia = await _context.LicenciasSoftware.FindAsync(id);
            if(licencia == null) return NotFound($"Licencia de software con ID {id} no existe");
            bool seModificoAlgo = false;
            if(!string.IsNullOrWhiteSpace(dto.NombreLicencia))
            {
                licencia.NombreLicencia = dto.NombreLicencia;
                seModificoAlgo = true;
            }
            if(dto.FechaExpiracion.HasValue)
            {
                licencia.FechaExpiracion = dto.FechaExpiracion.Value;
                seModificoAlgo = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.TipoLicencia))
            {
                licencia.TipoLicencia = dto.TipoLicencia;
                seModificoAlgo = true;
            }
            if (dto.EquipoId.HasValue && dto.EquipoId != licencia.EquipoId)
            {
                var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId);
                if (!equipoExiste)
                    return NotFound($"Equipo con ID {dto.EquipoId} no existe");
                licencia.EquipoId = dto.EquipoId;
                seModificoAlgo = true;
            }
            if(seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(licencia);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var licencia = await _context.LicenciasSoftware.FindAsync(id);
            if (licencia == null) return NotFound($"Licencia de software con ID {id} no existe");
            _context.LicenciasSoftware.Remove(licencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
