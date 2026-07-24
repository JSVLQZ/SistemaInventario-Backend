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
    public class ComponentesController:ControllerBase
    {
        private readonly InventarioDbContext _context;
            public ComponentesController(InventarioDbContext context)
            {
                _context = context;
            }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var componentes = await _context.Componentes.ToListAsync();
            return Ok(componentes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var componentes = await _context.Componentes.FindAsync(id);
            if (componentes == null) return NotFound($"El componenete con id {id} no existe");
            return Ok(componentes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComponentesCreateDto dto)
        {
            var componentes = new Componentes
            {
                EquipoId = dto.EquipoId,
                TipoComponente = dto.TipoComponente,
                Detalles = dto.Detalles,
                SerialComponente = dto.SerialComponente
            };
            _context.Componentes.Add(componentes);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = componentes.ComponentesId }, componentes);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComponentesUpdateDto dto)
        {
            var componentes = await _context.Componentes.FindAsync(id);
            if (componentes == null) return NotFound($"El componente con id {id} no existe");
            bool seModificoAlgo = false;
            if(dto.EquipoId != componentes.EquipoId)
            {
                componentes.EquipoId = dto.EquipoId;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.TipoComponente))
            {
                componentes.TipoComponente = dto.TipoComponente;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.Detalles))
            {
                componentes.Detalles = dto.Detalles;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(componentes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var componentes = await _context.Componentes.FindAsync(id);
            if (componentes == null) return NotFound($"El componente con id {id} no existe");
            _context.Componentes.Remove(componentes);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
