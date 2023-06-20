namespace Popsy.Objects
{
    public record ResultOrdenDeCompra
    {
        public string DocOC { get; set; } = default!;
        public string CodMaterial { get; set; } = default!;
        public string PositionDoc { get; set; } = default!;
        public string Centro { get; set; } = default!;
        public string UndCompra { get; set; } = default!;
        public string Cant_Pedida { get; set; } = default!;
        public string Date_Solped { get; set; } = default!;
        public string Proveedor { get; set; } = default!;
    }
}