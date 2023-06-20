namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz de negocio para los metodos almacenados.
    /// </summary>
    public interface IProcedimientoAlmacenadoBusiness
    {
        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="storedProcName">El nombre del procedimiento almacenado.</param>
        Task ExecuteStoredProc(string storedProcName);
        /// <summary>
        /// Ejecuta el procedimiento almacenado ProcedimientoSeguimientoPDV.
        /// </summary>
        Task<int> ProcedimientoSeguimientoPDV();
        /// <summary>
        /// Ejecuta el procedimiento almacenado sp_eliminar_pedidos con los parámetros especificados.
        /// </summary>
        /// <param name="año">El valor del parámetro ANHO.</param>
        /// <param name="mont">El valor del parámetro MONT.</param>
        /// <param name="day">El valor del parámetro DAY.</param>
        Task<int> ProcedimientoEliminarPedidos(int año, int mont, int day);
        /// <summary>
        /// Ejecuta el procedimiento almacenado SP_ELIMINAR_PRODUCTOS_TRANSACCIONALES.
        /// </summary>
        Task<int> ProcedimientoEliminarProductosTransaccionales();
    }
}
