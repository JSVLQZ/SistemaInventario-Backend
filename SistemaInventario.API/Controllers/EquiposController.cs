using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public EquiposController(InventarioDbContext context)
        {
            _context = context;
        }

        #region Método GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _context.Equipos.ToArrayAsync();
            return Ok(equipos);
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound();
            return Ok(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Equipos nuevoEquipo)
        {
            if (nuevoEquipo == null) return BadRequest();

            _context.Equipos.Add(nuevoEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), nuevoEquipo);
        }
    }
}