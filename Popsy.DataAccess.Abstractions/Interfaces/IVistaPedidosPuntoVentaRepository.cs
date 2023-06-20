using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaPedidosPuntoVentaRepository
    {
        Task<VistaPedidosPuntoVentaEntity?> GetVistaPedidosPuntoVenta(Guid pedido_id);

    }
}