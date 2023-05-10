using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProductosPuntosVentaRepository
    {
        Task<TblProductosPuntosVentaEntity> GetProductoPuntoVentaId(Guid producto_id, Guid punto_venta_id);
    }
}