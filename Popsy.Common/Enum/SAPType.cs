using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de envio.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SAPType : Int16
    {
        Inventario = 0,
        RecepcionDeCompra = 1,
        Pedido = 2,
    }
}
