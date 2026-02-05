using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura os serviços necessários
builder.Services.AddControllers(); 
builder.Services.AddOpenApi();

// Configura o banco de dados em memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MineracaoDb"));

var app = builder.Build();

// Configura o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Comente esta linha se estiver tendo problemas com certificados SSL locais
app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();