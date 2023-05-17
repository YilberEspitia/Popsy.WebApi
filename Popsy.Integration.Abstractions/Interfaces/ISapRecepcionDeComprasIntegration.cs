using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface ISapRecepcionDeComprasIntegration
    {
        Task<ResponseSAP<ResultOrdenDeCompra>> SyncOrdenesDeCompra(string codigo_almacen);
        Task<ResponseSAP<ResultProveedorRecepcion>> SyncProveedoresRecepcion();
        Task<string> EnviaRecepcionDeCompra();
    }
}
