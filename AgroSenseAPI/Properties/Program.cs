using AgroSenseAPI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("OracleDbContext");

builder.Services.AddDbContext<AgroSenseContext>(options =>
    options.UseOracle(connectionString));


// Outros serviços
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
