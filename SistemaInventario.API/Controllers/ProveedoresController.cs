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
    public class ProveedoresController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ProveedoresController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedor = await _context.Proveedores.ToListAsync();
            return Ok(proveedor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return NotFound($"El proveedor con ID {id} no existe");
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorCreateDto dto)
        {
            var proveedor = new Proveedores
            {
                NombreEmpresa = dto.NombreEmpresa,
                Nit = dto.Nit,
                CorreoSoporte = dto.CorreoSoporte,
                Telefono = dto.Telefono
            };
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proveedor.ProveedorId }, proveedor);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, [FromBody] ProveedorUpdateDto dto)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if(proveedor == null) return NotFound($"El proveedor con ID {id} no existe");
            bool seModificoAlgo = false;
            if (!string.IsNullOrWhiteSpace(dto.CorreoSoporte))
            {
                proveedor.CorreoSoporte = dto.CorreoSoporte.Trim();
                seModificoAlgo = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.Telefono))
            {
                proveedor.Telefono = dto.Telefono.Trim();
                seModificoAlgo = true;
            }
            if (!seModificoAlgo) return BadRequest("No se proporcionaron datos para actualizar");
            await _context.SaveChangesAsync();
            return Ok(proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if(proveedor == null) return NotFound($"El proveedor con ID {id} no existe");
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
