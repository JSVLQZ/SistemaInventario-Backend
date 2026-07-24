using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Update
{
    public class TicketsUpdateDto
    {
        public int? UserId { get; set; }
        public int? EquipoId { get; set; }
        public int? CategoriaId { get; set; }
        [StringLength(100, ErrorMessage = "El título del ticket no puede exceder los 100 caracteres")]
        public string? Titulo { get; set; }
        [StringLength(250, ErrorMessage = "La descripción del ticket no puede exceder los 250 caracteres")]
        public string? Descripcion { get; set; }
        [StringLength(50, ErrorMessage = "El estado del ticket no puede exceder los 50 caracteres")]
        public string? Estado { get; set; }

    }
}
