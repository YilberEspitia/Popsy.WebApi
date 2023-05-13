using Microsoft.Extensions.DependencyInjection;

using Popsy.Interfaces;
using Popsy.Repositories;

namespace Popsy
{
    /// <summary>
    /// Extensión para declarar los servicios de acceso a datos.
    /// </summary>
    public static class DataAccessServiceExtensions
    {
        /// <summary>
        /// Inyección de dependencias para el paquete de acceso a datos.
        /// </summary>
        /// <param name="services">Referencia de <see cref="IServiceCollection"/>.</param>
        /// <returns>Referencia de <see cref="IServiceCollection"/> después de la inyección de dependencias.</returns>
        public static IServiceCollection AddPopsyRepositories(this IServiceCollection services)
            => services
            .AddScoped<IDeterminarComprasTrasladosRepository, DeterminarComprasTrasladosRepository>()
            .AddScoped<IInventarioDetalleRepository, InventarioDetalleRepository>()
            .AddScoped<IInventariosRepository, InventariosRepository>()
            .AddScoped<IProductosPedidosRepository, ProductosPedidosRepository>()
            .AddScoped<IProductosPuntosVentaRepository, ProductosPuntosVentaRepository>()
            .AddScoped<IProductosRepository, ProductosRepository>()
            .AddScoped<IPuntosVentasRepository, PuntosVentasRepository>()
            .AddScoped<IReadInventarioBaseRepository, ReadInventarioBaseRepository>()
            .AddScoped<ITipoInventariosRepository, TipoInventariosRepository>()
            .AddScoped<IUsuariosPuntosVentasRepository, UsuariosPuntosVentasRepository>()
            .AddScoped<IVistaCategoriasProductosRepository, VistaCategoriasProductosRepository>()
            .AddScoped<IVistaMonitorInventarioRepository, VistaMonitorInventarioRepository>()
            .AddScoped<IVistaPedidosPuntoVentaRepository, VistaPedidosPuntoVentaRepository>()
            .AddScoped<IVistaProductoFactoresConversionRepository, VistaProductoFactoresConversionRepository>()
            .AddScoped<IVistaProductosConStockRepository, VistaProductosConStockRepository>()
            .AddScoped<IVistaProductosParaInventarioRepository, VistaProductosParaInventarioRepository>()
            .AddScoped<IVistaPuntosVentaBodegasRepository, VistaPuntosVentaBodegasRepository>()
            .AddScoped<IVistaResumenInventarioRepository, VistaResumenInventarioRepository>()
            .AddScoped<IProveedorRecepcionRepository, ProveedorRecepcionRepository>()
            .AddScoped<IOrdenDeCompraRepository, OrdenDeCompraRepository>()
            .AddScoped<IDetalleOrdenDeCompraRepository, DetalleOrdenDeCompraRepository>();
    }
}
