using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IIntegraciones
    {
        Task<RespuestaServicioEntity> GetRespuestaPedidoSAPIntegracion(Guid pedido_id);
    }
}