using Microsoft.Extensions.DependencyInjection;

namespace Popsy
{
    /// <summary>
    /// Extensión para declarar los servicios de integración.
    /// </summary>
    public static class IntegrationServiceExtensions
    {
        /// <summary>
        /// Inyección de dependencias para el paquete de integración.
        /// </summary>
        /// <param name="services">Referencia de <see cref="IServiceCollection"/>.</param>
        /// <returns>Referencia de <see cref="IServiceCollection"/> después de la inyección de dependencias.</returns>
        public static IServiceCollection AddPopsyIntegrations(this IServiceCollection services)
            => services;
    }
}
