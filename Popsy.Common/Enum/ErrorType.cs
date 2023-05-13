using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorType : Int16
    {
        ProveedorNoEncontrado = 0,
        PuntoDeVentaNoEncontrado = 1,
        DetalleDeVentaNoEncontrado = 2,
        OrdenDeCompraNoEncontrada = 3,
        RecepcionDeCompraNoEncontrada = 4,
        ProductoNoEncontrado = 5,
    }
}
