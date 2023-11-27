using Microsoft.EntityFrameworkCore;
using VendingMachineREST.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy =>
    {
        policy.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader();
    });
});

var optionBuilder = new DbContextOptionsBuilder<UsersDbContext>();
optionBuilder.UseSqlServer("Data Source = mssql4.unoeuro.com; Initial Catalog =  ozanhs_dk_db_vending_machine; Persist Security Info = True; User ID = ozanhs_dk; Password = GcB6m5g4awRnbE29tyzp; TrustServerCertificate = True");
UsersDbContext context = new UsersDbContext(optionBuilder.Options);
builder.Services.AddSingleton(new UsersRepository(context));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
