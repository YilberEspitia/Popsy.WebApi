namespace Popsy.Objects
{
    public class CreateInventarioBaseEntity
    {
        public Guid usuario_id { get; set; }
        public Guid tipo_inventario_id { get; set; }
        public DateTime fecha_registro { get; set; }
        public List<CreateInventarioBaseDetalleEntity> inventario_detalle { get; set; }
    }
}