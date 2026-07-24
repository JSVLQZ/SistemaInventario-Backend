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
            var perifericos = await _context.Perifericos.ToListAsync();
            return Ok(perifericos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var perifericos = await _context.Perifericos.FindAsync(id);
            if (perifericos == null) return NotFound($"Periférico con ID {id} no existe");
            return Ok(perifericos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerifericosCreateDto dto)
        {
            var perifericos = new Perifericos
            {
                SerialPeriferico = dto.SerialPeriferico,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                TipoPeriferico = dto.TipoPeriferico,
                UserId = dto.UsuarioId
            };
            _context.Perifericos.Add(perifericos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = perifericos.PerifericoId }, perifericos);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PerifericosUpdateDto dto)
        {
            var perifericos = await _context.Perifericos.FindAsync(id);
            if (perifericos == null) return NotFound($"Periférico con ID {id} no existe");
            bool seModificoAlgo = false;
            if (!string.IsNullOrWhiteSpace(dto.Marca))
            {
                perifericos.Marca = dto.Marca;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.Modelo))
            {
                perifericos.Modelo = dto.Modelo;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.TipoPeriferico))
            {
                perifericos.TipoPeriferico = dto.TipoPeriferico;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(perifericos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var perifericos = await _context.Perifericos.FindAsync(id);
            if (perifericos == null) return NotFound($"Periférico con ID {id} no existe");
            _context.Perifericos.Remove(perifericos);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
