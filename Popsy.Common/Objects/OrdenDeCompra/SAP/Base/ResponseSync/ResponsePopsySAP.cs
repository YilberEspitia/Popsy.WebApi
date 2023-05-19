using Popsy.Enums;

namespace Popsy.Objects
{
    public record ResponsePopsySAP
    {
        public string Codigo { get; set; }
        public AccionesBD Accion { get; set; }
        public string? Error { get; set; }
    }
}