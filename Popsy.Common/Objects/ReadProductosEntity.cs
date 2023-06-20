namespace Popsy.Objects
{
    public class ReadProductosEntity
    {
        public Guid producto_id { get; set; }
        public string producto_nombre { get; set; }
        public int cantidad { get; set; }
        public string categoria_producto { get; set; }

        public List<ReadPresentacionEntity>? presentacion { get; set; }
    }
}