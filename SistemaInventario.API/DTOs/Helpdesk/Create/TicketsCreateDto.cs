using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class TicketsCreateDto
    {
        [Required]
        public int UserId { get; set; }
        public int? EquipoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; } = string.Empty;

    }
}
