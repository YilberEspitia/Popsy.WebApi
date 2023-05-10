using Microsoft.Extensions.DependencyInjection;

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
            => services;
    }
}
