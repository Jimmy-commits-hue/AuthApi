using AuthApiBackend.Database;
using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Interfaces.IServices;
using AuthApiBackend.Repositories;
using AuthApiBackend.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactDetailsRepo, ContactDetailsRepo>();
builder.Services.AddScoped<IContactDetailsService, ContactDetailsService>();

Env.Load();
string Password = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
string password = Password.Split('\\')[1];

string connectionString = $"Server={builder.Configuration["connectionString:Server"]};Port={builder.Configuration["connectionString:Port"]}" +
    $";User={builder.Configuration["connectionString:User"]};Database={builder.Configuration["connectionString:Database"]};Password={password};";

builder.Services.AddDbContext<AuthApiDbContext>(options =>
{

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});


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
