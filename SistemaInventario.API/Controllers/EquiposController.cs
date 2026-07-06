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

        #region Método GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _context.Equipos.ToArrayAsync();
            return Ok(equipos);
        }
        #endregion

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
            if (dto == null) return BadRequest();

            var nuevoEquipo = new Equipos
            {
                Serial = dto.Serial,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                TipoEquipo = dto.TipoEquipo,
                Estado = dto.Estado,
                FechaCompra = dto.FechaCompra,
                MesesGarantia = dto.MesesGarantia,
                ProveedorId = dto.proveedorId
            };

            _context.Equipos.Add(nuevoEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), nuevoEquipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EquipoUpdateCompletoDto dto)
        {
            if (dto == null) return BadRequest("Datos invalidos");
            if (string.IsNullOrWhiteSpace(dto.Serial) ||
                string.IsNullOrWhiteSpace(dto.Marca) ||
                string.IsNullOrWhiteSpace(dto.Modelo) ||
                string.IsNullOrWhiteSpace(dto.TipoEquipo) ||
                string.IsNullOrWhiteSpace(dto.Estado))
            {
                return BadRequest("Todos los campos son obligatorios");
            }
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound($"El equipo con ID {id} no existe");

            var proveedorexiste = await _context.Proveedores.AnyAsync(p => p.ProveedorId == dto.ProveedorId);
            if (!proveedorexiste) return BadRequest($"El proveedor {dto.ProveedorId} no existe");

            equipo.Serial = dto.Serial.Trim();
            equipo.Marca = dto.Marca.Trim();
            equipo.Modelo = dto.Modelo.Trim();
            equipo.TipoEquipo = dto.TipoEquipo.Trim();
            equipo.Estado = dto.Estado.Trim();
            equipo.FechaCompra = dto.FechaCompra;
            equipo.MesesGarantia = dto.MesesGarantia;
            equipo.ProveedorId = dto.ProveedorId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] EquipoUpdateDto dto)
        {
            if (dto == null) return BadRequest("Datos invalidos");
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound($"El equipo con ID {id} no existe");
            if (dto.Estado != null)
            {
                if (string.IsNullOrWhiteSpace(dto.Estado)) return BadRequest("El estado no puede estar vacío");

                equipo.Estado = dto.Estado.Trim();
            }

            if (dto.RentingId != null)
            {
                var rentingExiste = await _context.Renting.AnyAsync(r => r.RentingId == dto.RentingId);
                if (!rentingExiste) return BadRequest($"El renting {dto.RentingId} no existe");
                equipo.RentingId = dto.RentingId;
            }

            await _context.SaveChangesAsync();
            return NoContent();
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