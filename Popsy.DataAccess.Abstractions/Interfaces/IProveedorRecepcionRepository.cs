using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProveedorRecepcionRepository
    {
        Task<bool> CreateAsync(TblProveedorRecepcionEntity ordenDeCompra);
        Task<bool> UpdateAsync(TblProveedorRecepcionEntity ordenDeCompra);
        Task<TblProveedorRecepcionEntity?> GetProveedorRecepcionAsync(String codigoSap);
        Task<TblProveedorRecepcionEntity?> GetProveedorRecepcionAsync(Guid id);
        Task<IEnumerable<TblProveedorRecepcionEntity>> GetProveedoresRecepcionAsync();
        Task<bool> ExisteAsync(Guid id);
    }
}
