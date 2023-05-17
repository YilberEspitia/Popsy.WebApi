namespace Popsy.Objects
{
    public record ResultOrdenDeCompra
    {
        public string DocOC { get; set; }
        public string CodMaterial { get; set; }
        public string PositionDoc { get; set; }
        public string Centro { get; set; }
        public string UndCompra { get; set; }
        public string Cant_Pedida { get; set; }
        public string Date_Solped { get; set; }
        public string Proveedor { get; set; }
    }
}