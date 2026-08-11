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
    public class EquiposController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public EquiposController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipo = await _context.Equipos.ToListAsync();
            return Ok(equipo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound($"El equipo con ID {id} no existe");
            return Ok(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipoCreateDto dto)
        {
            var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.ProveedorId == dto.ProveedorId);
            if (!proveedorExiste)
            {
                return NotFound($"El proveedor con ID {dto.ProveedorId} no existe.");
            }
            if (dto.RentingId.HasValue)
            {
                var rentingExiste = await _context.Renting.AnyAsync(r => r.RentingId == dto.RentingId);
                if (!rentingExiste)
                    return NotFound($"El renting con ID {dto.RentingId} no existe.");
            }
            var nuevoEquipo = new Equipos
            {
                Serial = dto.Serial,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                TipoEquipo = dto.TipoEquipo,
                FechaCompra = dto.FechaCompra,
                MesesGarantia = dto.MesesGarantia,
                ProveedorId = dto.ProveedorId
            };

            _context.Equipos.Add(nuevoEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = nuevoEquipo.EquipoId }, nuevoEquipo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound($"El equipo con ID {id} no existe");

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}