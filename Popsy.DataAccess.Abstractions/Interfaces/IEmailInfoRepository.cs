namespace Popsy.Interfaces
{
    public interface IEmailInfoRepository
    {
        Task<string> GetUsuarioMail(Guid usuario_id);
        Task<string> GetNombrePuntoDeVenta(Guid punto_venta_id);
        Task<string> GetTipoDeInventario(Guid tipo_inventario_id);
        Task<string> GetNombreProducto(Guid producto_id);
        Task<string> GetNombreBodega(Guid bodega_id);
        Task<string> GetProveedorRepcionPorRecepcion(Guid recepcion_id);
        Task<string> GetNombrePuntoDeVentaPorRecepcion(Guid recepcion_id);
    }
}