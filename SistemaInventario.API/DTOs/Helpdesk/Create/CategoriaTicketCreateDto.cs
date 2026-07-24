using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Helpdesk.Create
{
    public class CategoriaTicketCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        public string NombreCategoria { get; set; } = null!;
    }
}
