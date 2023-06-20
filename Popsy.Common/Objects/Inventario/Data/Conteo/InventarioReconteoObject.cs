namespace Popsy.Objects
{
    public class InventarioReconteoObject
    {
        #region Atributos
        public Guid Inventario_id { get; set; }
        public String Codigo { get; set; } = default!;
        #endregion

        #region Relaciones
        public IEnumerable<InventarioConteoObjectBasic> Reconteos { get; set; } = new HashSet<InventarioConteoObjectBasic>();
        #endregion
    }
}