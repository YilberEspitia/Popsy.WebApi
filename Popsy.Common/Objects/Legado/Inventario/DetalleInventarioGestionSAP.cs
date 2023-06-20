namespace Popsy.Objects
{
    public class DetalleInventarioGestionSAP
    {
        public Guid Producto_id { get; set; }
        public String Codigo { get; set; } = default!;
        public String Unidad { get; set; } = default!;
        public Double Cantidad { get; set; }
        public Double Stock_fecha { get; set; }
        public String? Unidad_consumo { get; set; }
        public Double? Unidad_consumo_total { get; set; }
        public String? Unidad_despacho { get; set; }
        public Double? Unidad_despacho_total { get; set; }
        public String? Unidad_conteo { get; set; }
        public Double? Unidad_conteo_total { get; set; }

    }
}
