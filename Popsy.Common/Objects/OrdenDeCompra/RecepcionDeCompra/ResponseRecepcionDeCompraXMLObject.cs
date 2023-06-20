namespace Popsy.Objects
{
    public class ResponseRecepcionDeCompraXMLObject
    {
        #region Atributos
        public String XML { get; set; } = default!;
        public IEnumerable<ResponseRecepcionDeCompraObject> Respuestas { get; set; } = new HashSet<ResponseRecepcionDeCompraObject>();
        #endregion
    }
}