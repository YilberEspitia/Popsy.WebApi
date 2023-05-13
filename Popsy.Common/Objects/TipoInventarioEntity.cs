namespace Popsy.Objects
{
    public class TipoInventarioEntity
    {
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public Guid tipo_inventario_id { get; set; }
        public string nombre_tipo_inventario { get; set; } = default!;
        public string? abreviatura_inventario { get; set; }
    }
}
