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
    public class AsignacionEquiposController : ControllerBase
    {
        private readonly InventarioDbContext _context;
        public AsignacionEquiposController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asignacion = await _context.AsignacionEquipos.ToListAsync();
            return Ok(asignacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asignacion = await _context.AsignacionEquipos.FindAsync(id);
            if (asignacion == null) return NotFound($"Asignación de equipo con ID {id} no existe.");
            return Ok(asignacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsignacionEquiposCreateDto dto)
        {
            var equipoExiste = await _context.Equipos.AnyAsync(e => e.EquipoId == dto.EquipoId);
            if (!equipoExiste)
            {
                return BadRequest("El equipo especificado no existe.");
            }
            var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UsuarioId);
            if (!usuarioExiste)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            var asignacionExistente = await _context.AsignacionEquipos
                .AnyAsync(a => a.EquipoId == dto.EquipoId);
            if (asignacionExistente)
            {
                return BadRequest("Ya existe una asignación de este equipo.");
            }
            var asignacion = new AsignacionEquipos
            {
                EquipoId = dto.EquipoId,
                UserId = dto.UsuarioId,
                FechaAsignacion = DateTime.Now,
                Observaciones = dto.Observaciones
            };
            var historico = new HistoricoAsignaciones
            {
                EquipoId = dto.EquipoId,
                UserId = dto.UsuarioId,
                FechaEntrega = DateTime.Now,
                FechaRecibido = null
            };
            _context.AsignacionEquipos.Add(asignacion);
            _context.HistoricoAsignaciones.Add(historico);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = asignacion.AsignacionId }, asignacion);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AsignacionEquiposUpdateDto dto)
        {

            var asignacion = await _context.AsignacionEquipos.FindAsync(id);
            if (asignacion == null) return NotFound($"Asignación de equipo con ID {id} no existe.");
            var usuarioAnterior = asignacion.UserId;
            bool seModificoAlgo = false;
            if (dto.UsuarioId.HasValue)
            {
                var usuarioExiste = await _context.Usuario.AnyAsync(u => u.UserId == dto.UsuarioId);
                if (!usuarioExiste)
                {
                    return BadRequest("El usuario especificado no existe.");
                }
                if (usuarioAnterior == dto.UsuarioId.Value)
                    return BadRequest("El usuario especificado es el mismo que el actual. No se realizaron cambios.");

                var historicoActual = await _context.HistoricoAsignaciones
                    .FirstOrDefaultAsync(h => h.EquipoId == asignacion.EquipoId && h.FechaRecibido == null);
                asignacion.UserId = dto.UsuarioId.Value;
                if (historicoActual != null)
                {
                    historicoActual.FechaRecibido = DateTime.Now;
                }
                var nuevoHistorico = new HistoricoAsignaciones
                {
                    EquipoId = asignacion.EquipoId,
                    UserId = dto.UsuarioId.Value,
                    FechaEntrega = DateTime.Now,
                    FechaRecibido = null
                };
                _context.HistoricoAsignaciones.Add(nuevoHistorico);
                seModificoAlgo = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.Observaciones))
            {
                asignacion.Observaciones = dto.Observaciones;
                seModificoAlgo = true;
            }
            if (seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
            return Ok(asignacion);
        }
    }
}
