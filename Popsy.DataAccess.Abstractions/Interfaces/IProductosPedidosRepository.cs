using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProductosPedidosRepository
    {
        Task<List<TblProductosPedidosEntity>> GetProductoPedidoId(Guid pedido_id);
    }
}