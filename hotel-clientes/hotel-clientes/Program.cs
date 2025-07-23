using hotel_clientes.Models;
using hotel_clientes.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<HotelClientesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Azure")));
builder.Services.AddDbContext<HotelClientesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<LocalizacionesServices>();
builder.Services.AddCors(options => options.AddPolicy("pruebas", politica => { politica.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); }));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api-docs/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Mi API V1");
        c.RoutePrefix = "api-docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("pruebas");
app.MapControllers();

app.Run();
