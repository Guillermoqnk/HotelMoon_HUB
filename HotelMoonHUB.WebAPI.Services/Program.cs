using HotelMoonHUB.Application.Services;
using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IService, Service>();
builder.Services.AddSingleton<IHotelLegsService, HotelLegsService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(x =>
    {
        x.DefaultApiVersion = new ApiVersion(1, 0);
        x.AssumeDefaultVersionWhenUnspecified = true;
        x.ReportApiVersions = true;
        x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
