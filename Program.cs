using System.Globalization;using Microsoft.EntityFrameworkCore;
using GeekGallery.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApiContext>(opt=>opt.UseInMemoryDatabase("PostsDb"));
var connectionString = builder.Configuration.GetConnectionString("MySqlConn");

builder.Services.AddDbContext<ApiContext>(opt
    => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
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