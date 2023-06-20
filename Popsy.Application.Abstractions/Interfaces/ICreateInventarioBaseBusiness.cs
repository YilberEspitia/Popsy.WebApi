using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface ICreateInventarioBaseBusiness
    {
        Task<RespuestaServicioEntity> CreateInventarioBase(CreateInventarioBaseEntity inventario_base);
        Task<UpdateInventarioBaseEntity> UpdateInventarioBase(UpdateInventarioBaseEntity inventario_base);
        void EnviarCorreoInventario(InventarioEmailObject inventarioEmail);
    }
}