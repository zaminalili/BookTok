using BookTok.API.Extensions;
using BookTok.Application.Extensions;
using BookTok.Infrastructure.Extensions;
using BookTok.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Create data seed
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IBooktokSeeder>();
await seeder.Seed();

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
