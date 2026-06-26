using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Capturar la cadena de conexión del appsettings
var connectionString = builder.Configuration.GetConnectionString("DbInventario");

// 2. Registrar el DbContext en el contenedor de dependencias
builder.Services.AddDbContext<InventarioDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("SistemaInventario.API"))); // <--- ¡Clave para las migraciones!

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// --- MIGRACIÓN AUTOMÁTICA POR CÓDIGO ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<InventarioDbContext>();

        // Papi, esto revisa si la BD no existe, la crea y le monta las tablas de una
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
