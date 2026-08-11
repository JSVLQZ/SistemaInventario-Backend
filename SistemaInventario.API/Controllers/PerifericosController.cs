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
    public class PerifericosController: ControllerBase
    {
        private readonly InventarioDbContext _context;
        public PerifericosController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var periferico = await _context.Perifericos.ToListAsync();
            return Ok(periferico);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var periferico = await _context.Perifericos.FindAsync(id);
            if (periferico == null) return NotFound($"Periférico con ID {id} no existe");
            return Ok(periferico);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerifericosCreateDto dto)
        {
            if(dto.UsuarioId.HasValue)
            {
                var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UsuarioId);
                if (!usuarioExiste) return NotFound($"Usuario con ID {dto.UsuarioId} no existe");
            }
            var periferico = new Perifericos
            {
                SerialPeriferico = dto.SerialPeriferico,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                TipoPeriferico = dto.TipoPeriferico,
                UserId = dto.UsuarioId
            };
            _context.Perifericos.Add(periferico);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = periferico.PerifericoId }, periferico);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PerifericosUpdateDto dto)
        {
            var periferico = await _context.Perifericos.FindAsync(id);
            if (periferico == null) return NotFound($"Periférico con ID {id} no existe");
            bool seModificoAlgo = false;
            if (dto.UserId.HasValue && periferico.UserId != dto.UserId.Value)
            {
                var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UserId);
                if (!usuarioExiste)
                    return NotFound($"Usuario con ID {dto.UserId} no existe");
                periferico.UserId = dto.UserId.Value;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(periferico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var periferico = await _context.Perifericos.FindAsync(id);
            if (periferico == null) return NotFound($"Periférico con ID {id} no existe");
            _context.Perifericos.Remove(periferico);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
