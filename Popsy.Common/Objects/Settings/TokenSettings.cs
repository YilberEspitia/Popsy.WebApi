namespace Popsy.Settings
{
    /// <summary>
    /// Settings para los tokens que son enviados en los headers.
    /// </summary>
    public class TokenSettings
    {
        /// <summary>
        /// Tiempo de vida extra para el token.
        /// </summary>
        public String TiempoVidaExtra { get; set; } = default!;
    }
}
