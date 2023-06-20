namespace Popsy.Objects
{
    public class UnidadInventarioDosRead
    {
        #region Atributos
        public Guid unidad_inventario_dos_id { get; set; }
        public String unidad_consumo { get; set; }
        public int? unidad_consumo_contador { get; set; }
        public String unidad_despacho { get; set; }
        public int? unidad_despacho_contador { get; set; }
        public String unidad_conteo { get; set; }
        public int? unidad_conteo_contador { get; set; }
        #endregion
        #region Relaciones
        public Guid producto_id { get; set; }
        #endregion
    }
}