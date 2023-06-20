namespace Popsy.Objects
{
    public class InventarioProductosRead
    {
        public Guid producto_id { get; set; }
        public string producto_nombre { get; set; }
        public int cantidad { get; set; }
        public string categoria_producto { get; set; }

        #region AtributosUnidades
        public UnidadInventarioDosRead? unidad_inventario { get; set; }
        #endregion
    }
}