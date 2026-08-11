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
    public class RentingController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public RentingController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var renting = await _context.Renting.ToListAsync();
            return Ok(renting);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var renting = await _context.Renting.FindAsync(id);
            if(renting == null) return NotFound($"El renting con ID {id} no existe");
            return Ok(renting);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RentingCreateDto dto)
        {

            if (dto.FechaFin <= dto.FechaInicio)
            {
                return BadRequest("La fecha de finalización no puede ser anterior a la fecha de inicio");
            }

            var renting = new Renting
            {
                EmpresaRenting = dto.EmpresaRenting,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                PagoMensual = dto.PagoMensual
            };

            _context.Renting.Add(renting);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = renting.RentingId }, renting);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RentingUpdateDto dto)
        {
            var renting = await _context.Renting.FindAsync(id);
            if(renting == null) return NotFound($"El renting con ID {id} no existe");
            bool seModificoAlgo = false;
            var nuevaFechaInicio = dto.FechaInicio ?? renting.FechaInicio;
            var nuevaFechaFin = dto.FechaFin ?? renting.FechaFin;
            if(nuevaFechaFin <= nuevaFechaInicio)
            {
                return BadRequest("La fecha de finalización no puede ser anterior a la fecha de inicio");
            }
            if (dto.FechaInicio.HasValue)
            {
                renting.FechaInicio = dto.FechaInicio.Value;
                seModificoAlgo = true;
            }
            if (dto.FechaFin.HasValue)
            {
                renting.FechaFin = dto.FechaFin.Value;
                seModificoAlgo = true;
            }
            if (dto.PagoMensual.HasValue)
            {
                renting.PagoMensual = dto.PagoMensual.Value;
                seModificoAlgo = true;
            }
            if (!seModificoAlgo)
            {
                return BadRequest("No se proporcionaron datos para actualizar");
            }
            await _context.SaveChangesAsync();
            return Ok(renting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var renting = await _context.Renting.FindAsync(id);
            if(renting == null) return NotFound($"El renting con ID {id} no existe");
            _context.Renting.Remove(renting);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
