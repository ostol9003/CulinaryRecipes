using System.Text.Json.Serialization;
using API.Mappings;
using API.Model.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CulinaryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CulinaryContext")
                         ?? throw new InvalidOperationException("Connection string 'CulinaryContext' not found.")));
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    option => 
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfiles());

}).CreateMapper());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
