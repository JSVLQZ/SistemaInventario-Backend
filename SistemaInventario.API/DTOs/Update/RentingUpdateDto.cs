using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.API.DTOs.Update
{
    public class RentingUpdateDto
    {
        public DateOnly? FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }

        [Range(0.1, double.MaxValue)]
        public Decimal? PagoMensual { get; set; }
    }
}