using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class CategoriaTicketCreateDto
    {
        [Required]
        [StringLength(100)]
        public string NombreCategoria { get; set; } = string.Empty;
    }
}