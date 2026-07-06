namespace SistemaInventario.API.DTOs.Update
{
    public class RentingUpdateDto
    {
        public string? EmpresaRenting { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Decimal? PagoMensual { get; set; }
    }
}
