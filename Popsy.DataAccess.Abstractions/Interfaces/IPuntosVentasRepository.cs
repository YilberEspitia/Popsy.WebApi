using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IPuntosVentasRepository
    {

        Task<TblPuntosVentasEntity> GetPuntoVentasId(Guid punto_venta_id);

    }
}