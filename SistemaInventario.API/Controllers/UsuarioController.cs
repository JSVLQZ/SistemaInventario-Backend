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
    public class UsuarioController : ControllerBase
    {
        private readonly InventarioDbContext _context;
        public UsuarioController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuario = await _context.Usuario.ToListAsync();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if(usuario == null) return NotFound($"El usuario {id} no existe");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dto)
        {
            var sedeExiste = await _context.Sedes.AnyAsync(s => s.UbicacionId == dto.UbicacionId);
            if (!sedeExiste)
                return BadRequest($"La sede con ID {dto.UbicacionId} no existe.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Cargo = dto.Cargo,
                UbicacionId = dto.UbicacionId
            };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = usuario.UserId }, usuario);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return NotFound($"El usuario {id} no existe");
            bool seModificoAlgo = false;
            if(!string.IsNullOrWhiteSpace(dto.Nombre))
            {
                usuario.Nombre = dto.Nombre.Trim();
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.Cargo))
            {
                usuario.Cargo = dto.Cargo.Trim();
                seModificoAlgo = true;
            }
            if(dto.UbicacionId.HasValue && dto.UbicacionId.Value != usuario.UbicacionId)
            {
                var sedeExiste = await _context.Sedes.AnyAsync(s => s.UbicacionId == dto.UbicacionId.Value);
                if (!sedeExiste)
                    return NotFound($"La sede con ID {dto.UbicacionId.Value} no existe.");

                usuario.UbicacionId = dto.UbicacionId.Value;
                seModificoAlgo = true;
            }
            if (!seModificoAlgo) 
                return BadRequest("No se proporcionaron datos para actualizar");

            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return NotFound($"El usuario {id} no existe");
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
