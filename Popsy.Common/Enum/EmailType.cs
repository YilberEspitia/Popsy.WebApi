using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de recepciones de compra.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EmailType : Int16
    {
        Inventario = 0,
        RecepcionDeCompra = 1,
    }
}
