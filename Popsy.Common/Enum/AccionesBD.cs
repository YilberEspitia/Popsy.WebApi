using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccionesBD : Int16
    {
        Creado = 0,
        Actualizado = 1,
        NoCreado = 2,
        NoActualizado = 3,
        Error = 4,
    }
}
