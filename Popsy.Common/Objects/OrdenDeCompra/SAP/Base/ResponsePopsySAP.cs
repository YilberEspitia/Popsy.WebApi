namespace Popsy.Objects
{
    public record ResponsePopsySAP
    {
        public string Codigo_sap { get; set; }
        public bool Creado { get; set; }
        public bool Actualizado { get; set; }
        public string? Error { get; set; }
    }
}