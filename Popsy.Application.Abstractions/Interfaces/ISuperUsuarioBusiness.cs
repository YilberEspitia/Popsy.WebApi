using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone la lógica de negocio que puede gestionar el super usuario.
    /// </summary>
    public interface ISuperUsuarioBusiness
    {
        /// <summary>
        /// Crea un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseSave"/> objeto.</param>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns><see cref="InventarioResponse"/> objeto.</returns>
        Task<InventarioResponse> CreateInventarioBaseAsync(InventarioBaseSave inventario_base, Guid punto_venta_id);
    }
}
