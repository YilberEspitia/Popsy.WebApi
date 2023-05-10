using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IDeterminarComprasTrasladosRepository
    {
        Task<List<TblDeterminarComprasTrasladosEntity>> GetDeterminarComprasTraslados();
    }
}