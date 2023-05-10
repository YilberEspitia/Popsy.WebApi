using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de tipos de error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorType : Int16
    {
    }
}
