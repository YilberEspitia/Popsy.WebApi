using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IProveedorRecepcionBusiness
    {
        Task<bool> CreateAsync(ProveedorRecepcionObject ordenDeCompra);
        Task<ProveedorRecepcionObject> GetProveedorRecepcionAsync(String codigoSap);
        Task<ProveedorRecepcionObject> GetProveedorRecepcionAsync(Guid id);
        Task<IEnumerable<ProveedorRecepcionObject>> GetProveedoresRecepcionAsync();
    }
}
