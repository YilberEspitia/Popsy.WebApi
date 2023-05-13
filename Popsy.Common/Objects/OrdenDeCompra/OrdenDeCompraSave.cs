namespace Popsy.Objects
{
    public class OrdenDeCompraSave
    {
        #region Atributos
        public Guid orden_compra_id { get; set; }
        public String orden_compra { get; set; } = default!;
        public DateTime fecha_orden_compra { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<DetalleOrdenDeCompraSave> detalles_ordenes_de_compra { get; protected set; } = new HashSet<DetalleOrdenDeCompraSave>();
        #endregion
    }
}