using LeadTechAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione a conex�o com o banco de dados Oracle
builder.Services.AddDbContext<LeadTechAPIContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection"));
});

// Adicione os servi�os necess�rios ao cont�iner.
builder.Services.AddControllers();

// Aprenda mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
