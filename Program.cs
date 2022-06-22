using OpsCenterApi.Model;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("test");
// Add services to the container.
builder.Services.AddDbContext<OpsCenterContext>(opt=>opt.UseInMemoryDatabase("Database"));
builder.Services.AddScoped<OpsCenterContext,OpsCenterContext>();
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

app.MapControllers();

app.Run();
