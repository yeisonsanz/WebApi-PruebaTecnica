using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*  --- REGISTRO DE LA CONEXIÓN DEL DBCONTEXT ---
    1. .AddDbContext<ApplicationDbContext> registra tu contexto en el contenedor de IoC.
    2. 'options => options.UseSqlServer(...)' indica que se usará SQL Server como proveedor de base de datos.
    3. 'builder.Configuration.GetConnectionString("ConexionSql")' busca la propiedad dentro 
        del archivo 'appsettings.json' (el equivalente a tu application.properties).
*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
