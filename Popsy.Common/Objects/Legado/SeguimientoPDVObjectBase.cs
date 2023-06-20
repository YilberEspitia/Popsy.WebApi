namespace Popsy.Objects
{
    public class SeguimientoPDVObjectBase : TicketsSeguimientoPDVObject
    {
        public String PuntoDeVenta { get; set; } = default!;
        public Guid Punto_venta_id { get; set; }
        public DateTime FechaUltimaActualizacionICG { get; set; }
        public DateTime FechaUltimaActualizacionTracker { get; set; }
        public PendientesPDVObject PendientesDetalle { get; set; } = default!;
    }
}
