namespace Popsy.Objects
{
    public class InventarioConteoSave
    {
        #region Atributos
        public Double Cantidad { get; set; }
        #endregion

        #region Relaciones
        public Guid Inventario_detalle_id { get; set; }
        #endregion
    }
}