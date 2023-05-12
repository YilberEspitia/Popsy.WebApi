using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IPuntosVentasRepository
    {

        Task<TblPuntoVentaEntity> GetPuntoVentasId(Guid punto_venta_id);

    }
}