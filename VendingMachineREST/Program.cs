using Microsoft.EntityFrameworkCore;
using VendingMachineREST.Models;

var builder = WebApplication.CreateBuilder(args);

var corsName = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsName, policy =>
    {
        policy.WithOrigins("https://nice-rock-09b5d2203.4.azurestaticapps.net").
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

app.UseCors(corsName);

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
