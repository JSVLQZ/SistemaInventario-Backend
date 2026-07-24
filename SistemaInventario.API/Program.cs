using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Capturar la cadena de conexión del appsettings
var connectionString = builder.Configuration.GetConnectionString("DbInventario");

// 2. Registrar el DbContext con versión manual de MariaDB
builder.Services.AddDbContext<InventarioDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MariaDbServerVersion(new Version(10, 4, 32)), // <--- Al pasarle la versión fija, no usa AutoDetect y NO se totea
        b => b.MigrationsAssembly("SistemaInventario.API")));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// --- MIGRACIÓN AUTOMÁTICA POR CÓDIGO ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<InventarioDbContext>();

        context.Database.EnsureCreated();

        Console.WriteLine("==================================================");
        Console.WriteLine("¡Base de datos 'inventario' creada melamente por código!");
        Console.WriteLine("==================================================");
    }
    catch (Exception ex)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine($"Pailas, se toteó la creación: {ex.Message}");
        Console.WriteLine("==================================================");
    }
}
// ---------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();