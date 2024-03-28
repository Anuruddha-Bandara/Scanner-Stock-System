
using Microsoft.OpenApi.Models;
using ScannerStockSystem.Application.Extensions;
using ScannerStockSystem.Infrastructure.Extensions;
using ScannerStockSystem.Persistence.Extensions; 
using ScannerStockSystem.WebAPI.Middlewares;
using ScannerStockSystem.BackgroundTasks.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(); 
builder.Services.AddBackgroundTasksLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();