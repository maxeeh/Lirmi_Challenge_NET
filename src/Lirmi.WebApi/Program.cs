using System.Runtime.CompilerServices;
using Lirmi.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);
var _MyCord = "MyCords";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(o =>
    o.AddPolicy(name: _MyCord, builder =>
        builder.WithOrigins("https://localhost:44398")
    .AllowAnyMethod()
    .AllowAnyHeader())

);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRepositories();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterConecctionLirmiDb(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_MyCord);
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
