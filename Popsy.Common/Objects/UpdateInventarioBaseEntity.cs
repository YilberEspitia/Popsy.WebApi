namespace Popsy.Objects
{
    public class UpdateInventarioBaseEntity
    {
        public Guid usuario_id { get; set; }
        public Guid inventario_id { get; set; }
        public List<CreateInventarioBaseDetalleEntity> inventario_detalle { get; set; }
    }
}