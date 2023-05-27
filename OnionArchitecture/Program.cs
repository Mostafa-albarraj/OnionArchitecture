using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Data;
using OnionArchitecture.Repositry.Employees;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionStrings = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionStrings));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


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
