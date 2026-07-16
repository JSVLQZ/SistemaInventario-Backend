using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Create
{
    public class RentingCreateDto
    {
        [Required(ErrorMessage = "El nombre de la empresa de renting es obligatorio")]
        public string EmpresaRenting { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización es obligatoria")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El pago mensual es obligatorio")]
        [Range(0.1, double.MaxValue, ErrorMessage = "El pago mensual debe ser un valor mayor a 0")]
        public decimal PagoMensual { get; set; }
    }
}
