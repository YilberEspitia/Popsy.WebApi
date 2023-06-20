namespace Popsy.Objects
{
    public class InventarioConteoObjectExportable
    {
        #region Atributos
        public Guid Producto_id { get; set; }
        public String? Nombre { get; set; }
        public IEnumerable<ReconteoObjectExportable> Reconteos { get; set; } = new HashSet<ReconteoObjectExportable>();
        #endregion

        #region Relaciones
        public Guid Inventario_detalle_id { get; set; }
        #endregion
    }
}