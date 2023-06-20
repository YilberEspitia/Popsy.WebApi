namespace Popsy.Objects
{
    public class ResponseRecepcionDeCompraXMLTotalObject
    {
        #region Atributos
        public Int32 Envios { get; set; }
        public Int32 Errores { get; set; }
        public ISet<ResponseRecepcionDeCompraXMLObject> Detalle { get; set; } = new HashSet<ResponseRecepcionDeCompraXMLObject>();
        #endregion
    }
}