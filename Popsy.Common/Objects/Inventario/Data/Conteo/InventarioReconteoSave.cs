namespace Popsy.Objects
{
    public class InventarioReconteoSave
    {
        #region Atributos
        public Guid Inventario_id { get; set; }
        #endregion

        #region Relaciones
        public IEnumerable<InventarioConteoSave> Detalles { get; set; } = new HashSet<InventarioConteoSave>();
        #endregion
    }
}