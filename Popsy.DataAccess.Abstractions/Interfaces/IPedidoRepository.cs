using Popsy.Entities;
using Popsy.Enums;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblStockTeoricoInventariosDos"/>.
    /// </summary>
    public interface IPedidoRepository
    {
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblPedidoEntity"/> con ese id.
        /// </summary>
        /// <param name="pedido_id"><see cref="TblPedidoEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteAsync(Guid pedido_id);
        /// <summary>
        /// Actualiza el estado de un pedido.
        /// </summary>
        /// <param name="pedido_id"><see cref="TblPedidoEntity"/> id.</param>
        /// <param name="nuevo_estado">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        Task<bool> UpdateEstadoAsync(Guid pedido_id, SAPEstado nuevo_estado);
    }
}
