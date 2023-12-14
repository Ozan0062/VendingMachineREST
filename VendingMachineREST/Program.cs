using Microsoft.EntityFrameworkCore;
using VendingMachineREST.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy =>
    {
        policy.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var userOptionBuilder = new DbContextOptionsBuilder<UsersDbContext>();
userOptionBuilder.UseSqlServer("Data Source = mssql4.unoeuro.com; Initial Catalog =  ozanhs_dk_db_vending_machine; Persist Security Info = True; User ID = ozanhs_dk; Password = GcB6m5g4awRnbE29tyzp; TrustServerCertificate = True");
UsersDbContext userContext = new UsersDbContext(userOptionBuilder.Options);
builder.Services.AddSingleton(new UsersRepository(userContext));

var accountingOptionBuilder = new DbContextOptionsBuilder<AccountingsDbContext>();
accountingOptionBuilder.UseSqlServer("Data Source = mssql4.unoeuro.com; Initial Catalog =  ozanhs_dk_db_vending_machine; Persist Security Info = True; User ID = ozanhs_dk; Password = GcB6m5g4awRnbE29tyzp; TrustServerCertificate = True");
AccountingsDbContext accountingsContext = new AccountingsDbContext(accountingOptionBuilder.Options);
builder.Services.AddSingleton(new AccountingsRepository(accountingsContext));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll");

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
