using Bibilioteca.Service;
using Biblioteca.Api.Context;
using Bibilioteca.Biblioteca.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Models.ExternalConnectors;
using System;
using System.Linq;





var builder = WebApplication.CreateBuilder(args);

// 1. Banco de Dados
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=Bibilioteca;Integrated Security=True;TrustServerCertificate=True"));

// 2. Injeção de Dependências (Services e Repositories)
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<EmprestimoService>();

builder.Services.AddScoped<PessoasRepository>();
builder.Services.AddScoped<LivrosRepository>();
builder.Services.AddScoped<EmprestimoRepository>();

// 3. CORS - Uma única política clara
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.AllowAnyOrigin()   // Permite o seu Live Server
              .AllowAnyMethod()   // Permite POST, GET, etc.
              .AllowAnyHeader();  // Permite JSON
    });
});

// 4. Configurações da API e Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// --- INÍCIO DO PIPELINE HTTP (A Ordem aqui é sagrada!) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// O CORS DEVE ficar exatamente aqui: entre o Https e o Authorization
app.UseCors("PermitirFrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
