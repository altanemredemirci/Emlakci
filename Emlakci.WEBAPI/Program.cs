using Emlakci.WEBAPI.Models.Context;
using Emlakci.WEBAPI.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EstateContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnect")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddTransient
//builder.Services.AddSingleton


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
