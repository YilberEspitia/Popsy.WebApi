#region Variables
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
#endregion

#region Services
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("CustommerConnection")))
#endregion

#region HTTP
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion