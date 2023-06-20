namespace Popsy.Objects
{
    public record ResultStockTeoricoDeInventario
    {
        public string Material { get; set; } = default!;
        public string almacen { get; set; } = default!;
        public string StockMax { get; set; } = default!;
        public string StockTransito { get; set; } = default!;
        public string LibreUtiliza { get; set; } = default!;
    }
}