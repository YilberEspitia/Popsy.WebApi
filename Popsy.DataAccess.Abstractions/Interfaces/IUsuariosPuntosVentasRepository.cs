using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IUsuariosPuntosVentasRepository
    {
        Task<IEnumerable<TblUsuarioPuntoVentaEntity>> GetUsuariosPuntosVentas(Guid usuario_id);
    }
}