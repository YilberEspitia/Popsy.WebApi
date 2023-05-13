using Microsoft.Extensions.DependencyInjection;

using Popsy.Business;
using Popsy.Interfaces;

namespace Popsy
{
    /// <summary>
    /// Extensión para declarar los servicios de aplicación.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Inyección de dependencias para el paquete de aplicación.
        /// </summary>
        /// <param name="services">Referencia de <see cref="IServiceCollection"/>.</param>
        /// <returns>Referencia de <see cref="IServiceCollection"/> después de la inyección de dependencias.</returns>
        public static IServiceCollection AddPopsyApplication(this IServiceCollection services)
            => services.AddScoped<ICreateInventarioBaseBusiness, CreateInventarioBaseBusiness>()
            .AddScoped<IProveedorRecepcionBusiness, ProveedorRecepcionBusiness>();
    }
}
