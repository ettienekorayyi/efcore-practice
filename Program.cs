using Microsoft.EntityFrameworkCore;
using efcore_practice.Model;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentDbContext>(opt =>
    opt.UseSqlite("Data Source=student.db"));

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

app.MapControllers();

// We need to create a scope and use the Service Provider 
// to use the service and call the GetRequiredService.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<StudentDbContext>();
    await context.Database.MigrateAsync();
    SeedData.Seed(context);
}
catch(Exception ex)
{
    Debug.WriteLine(ex);
}

app.Run();

