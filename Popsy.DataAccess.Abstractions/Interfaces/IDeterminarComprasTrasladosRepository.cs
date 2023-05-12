using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IDeterminarComprasTrasladosRepository
    {
        Task<List<TblDeterminarCompraTrasladoEntity>> GetDeterminarComprasTraslados();
    }
}