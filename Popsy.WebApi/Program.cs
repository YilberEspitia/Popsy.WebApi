using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Popsy;
using Popsy.Common;

#region Variables
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
String WebApiAssemblyName = typeof(Program).Assembly.GetName().Name!;
String XmlCommentsFilePath = Path.Combine(PopsyConstants.BasePath, $"{WebApiAssemblyName}.xml");
ConfigurationManager configuration = builder.Configuration;
String productVersion = configuration.GetSection("ProductVersion").Value!;
#endregion

#region Services
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PopsyDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddAutoMapper(typeof(ApplicationServiceExtensions))
    .AddPopsyApplication()
    .AddPopsyRepositories()
    .AddPopsyIntegrations();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(productVersion, new OpenApiInfo { Title = $"{WebApiAssemblyName}", Version = productVersion });
    c.IncludeXmlComments(XmlCommentsFilePath);
});
#endregion

#region HTTP
WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/{productVersion}/swagger.json", $"{WebApiAssemblyName} {productVersion}");
});
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion