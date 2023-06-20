using Microsoft.Extensions.DependencyInjection;

using Popsy.Helpers;
using Popsy.Integrations;
using Popsy.Interfaces;
using Popsy.Settings;

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
        /// <param name="settings">Referencia de <see cref="IntegracionPopsySettings"/>.</param>
        /// <param name="smtpSettings">Referencia de <see cref="SMTPSettings"/>.</param>
        /// <returns>Referencia de <see cref="IServiceCollection"/> después de la inyección de dependencias.</returns>
        public static IServiceCollection AddPopsyIntegrations(this IServiceCollection services, IntegracionPopsySettings settings, SMTPSettings smtpSettings)
            => services
            .AddSingleton(settings)
            .AddSingleton(smtpSettings)
            .AddScoped<XMLEnvioPedidoSAP>()
            .AddScoped<IIntegraciones, Integraciones>()
            .AddScoped<ISapClientesIntegration, SapClientesIntegration>()
            .AddScoped<ISapMaterialesIntegration, SapMaterialesIntegration>()
            .AddSingleton<ISapSyncIntegration, SapSyncIntegration>()
            .AddSingleton<IEmailService, EmailService>();
    }
}
