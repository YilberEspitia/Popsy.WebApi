namespace Popsy.Objects
{
    public class TipoInventarioRead
    {
        public Guid tipo_inventario_id { get; set; }
        public string nombre_tipo_inventario { get; set; } = default!;
        public string? abreviatura_inventario { get; set; }
    }
}
