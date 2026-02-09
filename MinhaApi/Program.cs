using Microsoft.EntityFrameworkCore;
using MinhaApi.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Registrar Postgres APENAS fora do ambiente de teste
if (!builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var cs = "Host=localhost;Port=5433;Database=minhaapi_db;Username=postgres;Password=postgres";

        options
            .UseNpgsql(cs)
            .UseSnakeCaseNamingConvention();
    });

    // Compatibilidade timestamp Npgsql
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }