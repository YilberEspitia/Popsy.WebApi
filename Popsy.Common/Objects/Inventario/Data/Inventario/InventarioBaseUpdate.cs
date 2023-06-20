namespace Popsy.Objects
{
    public class InventarioBaseUpdate
    {
        public Guid usuario_id { get; set; }
        public Guid inventario_id { get; set; }
        public List<DetalleInventarioBaseSave> inventario_detalle { get; set; }
    }
}