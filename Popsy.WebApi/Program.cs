using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using GT.Popsy.Middleware;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Popsy;
using Popsy.Attributes;
using Popsy.Common;
using Popsy.Filters;
using Popsy.Settings;

using Serilog;

#region Variables
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
String WebApiAssemblyName = typeof(Program).Assembly.GetName().Name!;
String XmlCommentsFilePath = Path.Combine(PopsyConstants.BasePath, $"{WebApiAssemblyName}.xml");
ConfigurationManager configuration = builder.Configuration;
String environmentName = "Prod";
String productVersion = configuration.GetSection("ProductVersion").Value!;
String databaseName = configuration.GetSection("DatabaseName").Value!;
Int32 httpsPort = 5001;
Int32.TryParse(configuration.GetSection("HttpsPort").Value!, out httpsPort);
IntegracionPopsySettings popsySettings = new();
configuration.GetSection("Integraciones:HeladosPopsy").Bind(popsySettings);
SMTPSettings smtpSettings = new();
configuration.GetSection("Integraciones:Correo").Bind(smtpSettings);
TokenSettings tokenSettings = new();
configuration.GetSection("TokenSettings").Bind(tokenSettings);
HostedServicesLifeTime lifeTimes = new();
configuration.GetSection("HostedServicesLifeTime").Bind(lifeTimes);
Byte[] jwt = Encoding.UTF8.GetBytes(configuration["Jwt"]);
IPAddress? ipv4Address = Dns.GetHostEntry(Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
#endregion

#region Services
if (!builder.Environment.IsDevelopment())
    builder.WebHost.UseKestrel(serverOptions =>
    {
        if (ipv4Address != default)
            serverOptions.Listen(ipv4Address, httpsPort,
                listenOptions =>
                {
                    listenOptions.UseHttps(new X509Certificate2("Certificate/all_heladospopsy_com_2023_2024.pfx", "FP5YmqrMDDCV"));
                });
    });
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExtenderTokenHeaderFilter>();
});
builder.Services.AddTransient<DisableAPIAttribute>();
builder.Services.AddTransient<DisableSwaggerAttribute>();
builder.Services.AddDbContext<PopsyDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddAutoMapper(typeof(ApplicationServiceExtensions))
    .AddSingleton(tokenSettings)
    .AddScoped<ExtenderTokenHeaderFilter>()
    .AddPopsyApplication()
    .AddPopsyRepositories()
    .AddHostedService<SyncTareaProgramadaOrdenes>()
    .AddHostedService<SyncTareaProgramadaStock>()
    .AddHostedService<ReenviarSAPTareaProgramada>()
    .AddPopsyIntegrations(popsySettings, smtpSettings)
    .AddSingleton(jwt)
    .AddSingleton(lifeTimes)
    .AddAuthorization(options =>
    {
        options.AddPolicy(PopsyConstants.UserSIPOP, policy =>
        {
            policy.RequireAssertion(context => context.User.HasClaim(c => c.Type.Equals(PopsyConstants.Estado) && c.Value.Equals(PopsyConstants.EstadoActivo)));
        });
        options.AddPolicy(PopsyConstants.ControlInventarios, policy =>
        {
            policy.RequireRole(PopsyConstants.RolSU, PopsyConstants.RolControlInventario);
            policy.RequireAssertion(context => context.User.HasClaim(c => c.Type.Equals(PopsyConstants.Estado) && c.Value.Equals(PopsyConstants.EstadoActivo)));
        });
        options.AddPolicy(PopsyConstants.SuperUserSIPOP, policy =>
        {
            policy.RequireRole(PopsyConstants.RolSU);
            policy.RequireAssertion(context => context.User.HasClaim(c => c.Type.Equals(PopsyConstants.Estado) && c.Value.Equals(PopsyConstants.EstadoActivo)));
        });
    })
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwt),
            ClockSkew = TimeSpan.Zero
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(productVersion, new OpenApiInfo { Title = $"{WebApiAssemblyName}", Version = productVersion });
    c.IncludeXmlComments(XmlCommentsFilePath);
    c.DocumentFilter<DisableSwaggerDocumentFilter>();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }});
});
builder.Services.AddCors();
builder.Logging.AddSerilog(new LoggerConfiguration()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger());
#endregion

#region HTTP
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    environmentName = "Dev";
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocumentTitle = $"BackendSIPOP - {environmentName}";
    c.SwaggerEndpoint($"/swagger/{productVersion}/swagger.json", $"{WebApiAssemblyName} {productVersion} - {databaseName}");
});
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);
app.UseMiddleware<PopsyMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion