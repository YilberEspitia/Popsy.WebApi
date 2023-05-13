namespace Popsy.Objects
{
    public class ProveedorRecepcionObject
    {
        #region Atributos
        public Guid proveedor_recepcion_id { get; set; }
        public string nombre { get; set; } = default!;
        public string codigo_sap_proveedor { get; set; } = default!;
        #endregion
    }
}