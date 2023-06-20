using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StockValidaciones : Int16
    {
        Igual = 0,
        Superior = 1,
        Inferior = 2,
        SinValidar = 3
    }
}
