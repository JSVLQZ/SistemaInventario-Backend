using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class TicketsCreateDto
    {
        [Required(ErrorMessage = "El id del usuario es requerido")]
        public int? UserId { get; set; }
        public int? EquipoId { get; set; }

        [Required(ErrorMessage = "El id de la categoría es requerido")]
        public int? CategoriaId { get; set; }

        [Required(ErrorMessage = "El título del ticket es requerido")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "La descripción del ticket es requerida")]
        public string? Descripcion { get; set; }

    }
}
