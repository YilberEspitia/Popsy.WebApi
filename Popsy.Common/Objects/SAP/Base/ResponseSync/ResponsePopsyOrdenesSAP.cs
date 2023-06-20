using Popsy.Enums;

namespace Popsy.Objects
{
    public record ResponsePopsyOrdenesSAP
    {
        public string Codigo { get; set; } = default!;
        public AccionesBD Accion { get; set; }
        public string? Error { get; set; }
        public ISet<ResponsePopsyOrdenesDetallesSAP> Detalles { get; set; } = new HashSet<ResponsePopsyOrdenesDetallesSAP>();
    }
}