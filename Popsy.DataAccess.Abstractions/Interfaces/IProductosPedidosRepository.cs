using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProductosPedidosRepository
    {
        Task<List<TblProductoPedidoEntity>> GetProductoPedidoId(Guid pedido_id);
    }
}