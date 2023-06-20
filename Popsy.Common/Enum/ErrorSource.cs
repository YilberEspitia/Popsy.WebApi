using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorSource : Int16
    {
        NoEncontrado = 0,
        Proceso = 1,
        Servidor = 2,
    }
}
