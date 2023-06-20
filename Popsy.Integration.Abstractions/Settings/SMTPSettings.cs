namespace Popsy.Settings
{
    /// <summary>
    /// Configuración para SMTP.
    /// </summary>
    public record SMTPSettings
    {
        /// <summary>
        /// Servidor.
        /// </summary>
        public String SmtpServer { get; set; } = default!;
        /// <summary>
        /// Puerto.
        /// </summary>
        public String SmtpPort { get; set; } = default!;
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public String SmtpUsername { get; set; } = default!;
        /// <summary>
        /// Contraseña.
        /// </summary>
        public String SmtpPassword { get; set; } = default!;
        /// <summary>
        /// Origen del correo de inventarios.
        /// </summary>
        public String OrigenInventario { get; set; } = default!;
        /// <summary>
        /// Asunto del correo de inventarios.
        /// </summary>
        public String AsuntoInventario { get; set; } = default!;
        /// <summary>
        /// Origen del correo de recepciones.
        /// </summary>
        public String OrigenRecepcion { get; set; } = default!;
        /// <summary>
        /// Asunto del correo de recepciones.
        /// </summary>
        public String AsuntoRecepcion { get; set; } = default!;
    }
}
