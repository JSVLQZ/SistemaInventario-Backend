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
            var componente = await _context.Componentes.ToListAsync();
            return Ok(componente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return NotFound($"El componente con id {id} no existe");
            return Ok(componente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComponentesCreateDto dto)
        {
            var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId);
            if (!equipoExiste)
            {
                return NotFound($"El equipo con ID {dto.EquipoId} no existe.");
            }
            var componente = new Componentes
            {
                EquipoId = dto.EquipoId,
                TipoComponente = dto.TipoComponente,
                Detalles = dto.Detalles,
                SerialComponente = dto.SerialComponente
            };
            _context.Componentes.Add(componente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = componente.ComponentesId }, componente);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComponentesUpdateDto dto)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return NotFound($"El componente con id {id} no existe");
            bool seModificoAlgo = false;
            if(dto.EquipoId.HasValue && dto.EquipoId != componente.EquipoId)
            {
                var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId);
                if (!equipoExiste)
                {
                    return NotFound($"El equipo con ID {dto.EquipoId} no existe.");
                }
                componente.EquipoId = dto.EquipoId;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.TipoComponente))
            {
                componente.TipoComponente = dto.TipoComponente;
                seModificoAlgo = true;
            }
            if(!string.IsNullOrWhiteSpace(dto.Detalles))
            {
                componente.Detalles = dto.Detalles;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(componente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return NotFound($"El componente con id {id} no existe");
            _context.Componentes.Remove(componente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
