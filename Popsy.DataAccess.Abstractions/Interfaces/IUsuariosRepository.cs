using Popsy.Entities;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<TblUsuarioPuntoVentaEntity>> GetUsuariosPuntosVentas(Guid usuario_id, bool activos = false);
        Task<IEnumerable<Guid>> GetUsuariosPuntosVentas2(Guid usuario_id, bool activos = false);
        Task<IEnumerable<PuntoDeVentaInfoRead>> GetPuntosDeVentaInfoAsync(Guid usuario_id);
        Task<IEnumerable<PuntoDeVentaInfoRead>> GetAllPuntosDeVentaInfoAsync();
        Task<String?> GetNombreDeUsuarioAsync(Guid usuario_id);
        Task<IEnumerable<TblTipoInventarioEntity>> GetTipoInventariosAsync();
        Task<Boolean> EsSuperUsuario(Guid usuario_id);
    }
}