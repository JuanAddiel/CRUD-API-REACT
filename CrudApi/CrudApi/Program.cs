using CrudApi.Core.Application;
using CrudApi.Extensions;
using CrudApi.Infrastructured.Persistence;
using CrudApi.Infrastructured.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLayerApplication();
builder.Services.AddApiVersioningExtension();
builder.Services.AddLayerPersistence(builder.Configuration);
builder.Services.AddLayerPersistence(builder.Configuration);
builder.Services.AddLayerShared(builder.Configuration);
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
