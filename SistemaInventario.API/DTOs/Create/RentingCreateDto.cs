using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class RentingCreateDto
    {
        [Required]
        [StringLength(150)]
        public string EmpresaRenting { get; set; } = string.Empty;
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "El pago mensual debe ser un valor mayor a 0")]
        public decimal PagoMensual { get; set; }
    }
}