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
            var licencias = await _context.LicenciasSoftware.ToListAsync();
            return Ok(licencias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var licencias = await _context.LicenciasSoftware.FindAsync(id);
            if (licencias == null) return NotFound($"Licencia de software con ID {id} no existe");
            return Ok(licencias);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LicenciasSoftwareCreateDto dto)
        {
            var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId!.Value);
            if(!equipoExiste) return NotFound($"Equipo con ID {dto.EquipoId} no existe");

            var licencias = new LicenciasSoftware
            {
                NombreLicencia = dto.NombreLicencia,
                ClaveActivacion = dto.ClaveActivacion,
                FechaExpiracion = dto.FechaExpiracion!.Value,
                TipoLicencia = dto.TipoLicencia,
                EquipoId = dto.EquipoId!.Value
            };
            _context.LicenciasSoftware.Add(licencias);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = licencias.LicenciaId }, licencias);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LicenciasSoftwareUpdateDto dto)
        {
            var licencias = await _context.LicenciasSoftware.FindAsync(id);
            if(licencias == null) return NotFound($"Licencia de software con ID {id} no existe");
            bool seModificoAlgo = false;
            if(!string.IsNullOrWhiteSpace(dto.NombreLicencia))
            {
                licencias.NombreLicencia = dto.NombreLicencia;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.TipoLicencia))
            {
                licencias.TipoLicencia = dto.TipoLicencia;
                seModificoAlgo = true;
            }
            if(seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(licencias);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var licencias = await _context.LicenciasSoftware.FindAsync(id);
            if (licencias == null) return NotFound($"Licencia de software con ID {id} no existe");
            _context.LicenciasSoftware.Remove(licencias);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
