using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface ITipoInventariosRepository
    {
        Task<TblTipoInventarioEntity?> GetTipoInventarioById(Guid tipo_inventarios_id);
        Task<IEnumerable<TblTipoInventarioEntity>> GetTipoInventario();
    }
}