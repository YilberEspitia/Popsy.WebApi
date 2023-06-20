namespace Popsy.Objects
{
    public class UnidadInventarioDosObject
    {
        #region Atributos
        public Guid unidad_inventario_dos_id { get; set; }
        public String unidad_consumo { get; set; }
        public String unidad_despacho { get; set; }
        public String unidad_conteo { get; set; }
        #endregion
        #region Relaciones
        public Guid producto_id { get; set; }
        #endregion
    }
}