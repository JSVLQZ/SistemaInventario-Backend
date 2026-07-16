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
            var usuarios = await _context.Usuario.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarios = await _context.Usuario.FindAsync(id);
            if(usuarios == null) return NotFound($"El usuario {id} no existe");
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre.Trim(),
                Correo = dto.Correo.Trim().ToLower(),
                Cargo = dto.Cargo.Trim(),
                UbicacionId = dto.UbicacionId
            };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = usuario.UserId }, usuario);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDto dto)
        {
            var usuarios = await _context.Usuario.FindAsync(id);
            if (usuarios == null) return NotFound($"El usuario {id} no existe");
            bool seModificoAlgo = false;
            if(!string.IsNullOrWhiteSpace(dto.Nombre))
            {
                usuarios.Nombre = dto.Nombre.Trim();
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.Cargo))
            {
                usuarios.Cargo = dto.Cargo.Trim();
                seModificoAlgo = true;
            }
            if (!seModificoAlgo) return BadRequest("No se proporcionaron datos para actualizar");
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarios = await _context.Usuario.FindAsync(id);
            if (usuarios == null) return NotFound($"El usuario {id} no existe");
            _context.Usuario.Remove(usuarios);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
