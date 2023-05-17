using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface ISapRecepcionDeComprasIntegration
    {
        Task<ResponseOrdenDeCompra> SyncOrdenesDeCompra(string codigo_almacen);
        Task<ResponseProveedorRecepcion> SyncProveedoresRecepcion();
        Task<string> EnviaRecepcionDeCompra();
    }
}
