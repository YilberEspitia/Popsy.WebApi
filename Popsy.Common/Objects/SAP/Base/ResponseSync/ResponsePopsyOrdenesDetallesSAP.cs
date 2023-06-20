using Popsy.Enums;

namespace Popsy.Objects
{
    public record ResponsePopsyOrdenesDetallesSAP
    {
        public Guid detalle_orden_compra_id { get; set; } = default!;
        public AccionesBD Accion { get; set; }
        public string? Error { get; set; }
    }
}