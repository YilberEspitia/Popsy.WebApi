using Popsy.Enums;

namespace Popsy.Objects
{
    public class DetalleSeguimientoPDVObject
    {
        public Guid Id { get; set; }
        public String Codigo { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public SAPEstado Estado { get; set; }
        public SAPType Tipo { get; set; }
        public String? Mensaje_error { get; set; }
        public IEnumerable<String?> Mensajes { get; set; } = new HashSet<String>();
    }
}
