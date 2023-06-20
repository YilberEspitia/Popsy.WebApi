namespace Popsy.Objects
{
    public class EncabezadoInventarioRead
    {
        public Guid Usuario_id { get; set; }
        public String Usuario_nombre { get; set; } = default!;
        public IEnumerable<PuntoDeVentaInfoRead> Puntos_venta { get; set; } = new HashSet<PuntoDeVentaInfoRead>();
        public IEnumerable<TipoInventarioRead> Tipo_inventario { get; set; } = new HashSet<TipoInventarioRead>();
    }
}