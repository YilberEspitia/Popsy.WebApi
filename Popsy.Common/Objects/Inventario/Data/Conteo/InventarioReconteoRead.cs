namespace Popsy.Objects
{
    public class InventarioReconteoRead
    {
        #region Atributos
        public Guid Inventario_id { get; set; }
        public Boolean RequiereReconteo { get; set; }
        #endregion

        #region Relaciones
        public IEnumerable<InventarioConteoRead> Detalles { get; set; } = new HashSet<InventarioConteoRead>();
        #endregion
    }
}