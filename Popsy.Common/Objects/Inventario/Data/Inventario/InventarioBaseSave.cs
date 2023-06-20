namespace Popsy.Objects
{
    public class InventarioBaseSave
    {
        public Guid usuario_id { get; set; }
        public Guid tipo_inventario_id { get; set; }
        public IEnumerable<DetalleInventarioBaseSave> inventario_detalle { get; set; } = new HashSet<DetalleInventarioBaseSave>();
    }
}