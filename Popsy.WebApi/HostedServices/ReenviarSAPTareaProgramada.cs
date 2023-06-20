using Newtonsoft.Json;

using Popsy.Interfaces;
using Popsy.Objects;
using Popsy.Settings;

/// <summary>
/// Tarea programada de sincronización de información.
/// </summary>
public class ReenviarSAPTareaProgramada : IHostedService, IDisposable
{
    /// <summary>
    /// Logger.
    /// </summary>
    private readonly ILogger<SyncTareaProgramadaStock> _logger;
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
    public ReenviarSAPTareaProgramada(ILogger<SyncTareaProgramadaStock> logger, IServiceScopeFactory serviceScopeFactory, HostedServicesLifeTime servicesLifeTime)
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
        _logger.LogInformation("ReenviarSAPTareaProgramada is starting.");
        // Calcular el próximo tiempo de ejecución
        DateTime nextExecutionTime = DateTime.Now.AddHours(_servicesLifeTime.ReenvioSAPHour);
        // Si el próximo tiempo de ejecución ya ha pasado, agregar el número de horas de repetición para obtener el próximo tiempo válido
        if (nextExecutionTime <= DateTime.Now)
            nextExecutionTime = DateTime.Now.AddHours(_servicesLifeTime.ReenvioSAPHour);
        // Calcular el tiempo de espera inicial hasta el próximo tiempo de ejecución
        TimeSpan initialDelay = nextExecutionTime - DateTime.Now;

        // Crear un temporizador que se active en el próximo tiempo de ejecución y luego se repita cada _servicesLifeTime.ReenvioSAPHour horas
        _timer = new Timer(async (state) =>
        {
            await ExecuteTaskAsync(state!);
            // Calcular el siguiente tiempo de ejecución en función del número de horas de repetición
            nextExecutionTime = nextExecutionTime.AddHours(_servicesLifeTime.ReenvioSAPHour);
            // Si el próximo tiempo de ejecución ya ha pasado, agregar el número de horas de repetición para obtener el próximo tiempo válido
            if (nextExecutionTime <= DateTime.Now)
                nextExecutionTime = DateTime.Now.AddHours(_servicesLifeTime.ReenvioSAPHour);
            // Calcular el tiempo de espera hasta el próximo tiempo de ejecución
            TimeSpan delay = nextExecutionTime - DateTime.Now;
            // Reiniciar el temporizador con el nuevo tiempo de espera
            _timer.Change(delay, TimeSpan.FromMilliseconds(-1));
        }, null, initialDelay, TimeSpan.FromMilliseconds(-1));

        return Task.CompletedTask;
    }


    private async Task ExecuteTaskAsync(object state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            ILegadoBusiness legado = scope.ServiceProvider.GetRequiredService<ILegadoBusiness>();
            _logger.LogInformation($"Reenvio a SAP ejecutado a las: {DateTime.Now}");
            ResponseRecepcionDeCompraXMLTotalObject response = await legado.EnviarRecepcionesDeCompra();
            _logger.LogInformation(JsonConvert.SerializeObject(response));
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
        _logger.LogInformation("SyncTareaProgramadaStock is stopping.");

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
