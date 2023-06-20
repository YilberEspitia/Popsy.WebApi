namespace Popsy.Objects
{
    public class InventarioReconteoExportable
    {
        #region Atributos
        public Guid Inventario_id { get; set; }
        public String Codigo { get; set; } = default!;
        public Boolean RequiereReconteo { get; set; }
        #endregion

        #region Relaciones
        public IEnumerable<InventarioConteoObjectExportable> Detalles { get; set; } = new HashSet<InventarioConteoObjectExportable>();
        #endregion
    }
}