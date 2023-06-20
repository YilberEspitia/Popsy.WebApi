namespace Popsy.Settings
{
    /// <summary>
    /// Configuración de tiempos de vida para las tareas programadas.
    /// </summary>
    public record HostedServicesLifeTime
    {
        /// <summary>
        /// Hora de ejecución para la tarea programada de ordenes de compra.
        /// </summary>
        public Int32 OrdenesExecutionHour { get; set; }
        /// <summary>
        /// Minuto de ejecución para la tarea programada de ordenes de compra.
        /// </summary>
        public Int32 OrdenesExecutionMinute { get; set; }
        /// <summary>
        /// Hora de ejecución para la tarea programada de sincronización de stock.
        /// </summary>
        public Int32 StockExecutionHour { get; set; }
        /// <summary>
        /// Minuto de ejecución para la tarea programada de sincronización de stock.
        /// </summary>
        public Int32 StockExecutionMinute { get; set; }
        /// <summary>
        /// Indica que se intenta reenviar a SAP cada x horas.
        /// </summary>
        public Int32 ReenvioSAPHour { get; set; }
    }
}
