namespace Popsy.Objects
{
    public class InventarioResponse
    {
        public String Respuesta { get; set; } = default!;
        public Guid Inventario_id { get; set; }
        public Boolean TieneTickets { get; set; } = default!;
        public Boolean Reconteo { get; set; } = default!;
        public IEnumerable<DetalleInventarioCreadoResponse> Detalles { get; set; } = new HashSet<DetalleInventarioCreadoResponse>();
    }
}