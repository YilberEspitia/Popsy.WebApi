namespace Popsy.Objects
{
    public class InventarioConteoObject
    {
        #region Atributos
        public Double cantidad { get; set; }
        public Boolean inicial { get; set; }
        public Boolean final { get; set; }
        #endregion

        #region Relaciones
        public Guid inventario_detalle_id { get; set; }
        #endregion
    }
}