using System.Text.Json.Serialization;

namespace Popsy.Enums
{
    /// <summary>
    /// Enum de estados de SAP.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SAPEstado : Int16
    {
        Pendiente = 0,
        Enviado = 1,
        Descartado = 2,
    }
}
