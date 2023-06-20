using Newtonsoft.Json;

using Popsy.Interfaces;
using Popsy.Objects;
using Popsy.Settings;

/// <summary>
/// Tarea programada de sincronización de información.
/// </summary>
public class SyncTareaProgramadaOrdenes : IHostedService, IDisposable
{
    /// <summary>
    /// Logger.
    /// </summary>
    private readonly ILogger<SyncTareaProgramadaOrdenes> _logger;
    /// <summary>
    /// <see cref="Timer"/> instancia.
    /// </summary>
    private Timer _timer = default!;
    /// <summary>
    /// Indica el siguiente tiempo de ejecución.
    /// </summary>
    private DateTime _nextExecutionTime;
    /// <summary>
    /// <see cref="IServiceScopeFactory"/> instancia.
    /// </summary>
    private readonly IServiceScopeFactory _serviceScopeFactory;
    /// <summary>
    /// <see cref="HostedServicesLifeTime"/> instancia.
    /// </summary>
    private readonly HostedServicesLifeTime _servicesLifeTime;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="serviceScopeFactory"><see cref="IServiceScopeFactory"/> instancia.</param>
    /// <param name="servicesLifeTime"><see cref="HostedServicesLifeTime"/> instancia.</param>
    public SyncTareaProgramadaOrdenes(ILogger<SyncTareaProgramadaOrdenes> logger, IServiceScopeFactory serviceScopeFactory, HostedServicesLifeTime servicesLifeTime)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _servicesLifeTime = servicesLifeTime;
    }

    /// <summary>
    /// Comienzo de la tarea programada.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("SyncTareaProgramadaOrdenes is starting.");
        // Calcular el próximo tiempo de ejecución
        _nextExecutionTime = DateTime.Today.AddHours(_servicesLifeTime.OrdenesExecutionHour).AddMinutes(_servicesLifeTime.OrdenesExecutionMinute);

        if (_nextExecutionTime <= DateTime.Now)
        {
            // Si el próximo tiempo de ejecución ya ha pasado hoy, agregar 1 día
            _nextExecutionTime = _nextExecutionTime.AddDays(1);
        }

        // Calcular el tiempo de espera inicial hasta el próximo tiempo de ejecución
        TimeSpan initialDelay = _nextExecutionTime - DateTime.Now;

        // Crear un temporizador que se active en el próximo tiempo de ejecución y luego se repita diariamente
        _timer = new Timer(async (state) => await ExecuteTaskAsync(state!), null, initialDelay, TimeSpan.FromDays(1));

        return Task.CompletedTask;
    }

    private async Task ExecuteTaskAsync(object state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            IOrdenDeCompraBusiness ordenes = scope.ServiceProvider.GetRequiredService<IOrdenDeCompraBusiness>();
            IProveedorRecepcionBusiness proveedorRecepcion = scope.ServiceProvider.GetRequiredService<IProveedorRecepcionBusiness>();
            _logger.LogInformation($"Sincronización de proveedores a las: {DateTime.Now}");
            IEnumerable<ResponsePopsySAP> responseProv = await proveedorRecepcion.SyncSAPAsync();
            _logger.LogInformation(JsonConvert.SerializeObject(responseProv));
            _logger.LogInformation($"Sincronización de ordenes a las: {DateTime.Now}");
            IEnumerable<ResponseOrdenesPopsySAP> responseOrdenes = await ordenes.SyncSAPAsync();
            _logger.LogInformation(JsonConvert.SerializeObject(responseOrdenes));
        }

        // Calcular el próximo tiempo de ejecución
        _nextExecutionTime = _nextExecutionTime.AddDays(1);
    }

    /// <summary>
    /// Tarea para detener.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("SyncTareaProgramada is stopping.");

        // Detener el temporizador
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Disponse.
    /// </summary>
    public void Dispose()
    {
        _timer?.Dispose();
    }
}
