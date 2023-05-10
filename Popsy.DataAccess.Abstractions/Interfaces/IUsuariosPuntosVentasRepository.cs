using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IUsuariosPuntosVentasRepository
    {
        Task<IEnumerable<TblUsuariosPuntosVentasEntity>> GetUsuariosPuntosVentas(Guid usuario_id);
    }
}