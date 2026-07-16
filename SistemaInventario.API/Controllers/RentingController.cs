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
                EmpresaRenting = dto.EmpresaRenting.Trim(),
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
            if(!string.IsNullOrWhiteSpace(dto.EmpresaRenting))
            {
                renting.EmpresaRenting = dto.EmpresaRenting.Trim();
                seModificoAlgo = true;
            }
            if(seModificoAlgo)
            {
                await _context.SaveChangesAsync();
            }
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
