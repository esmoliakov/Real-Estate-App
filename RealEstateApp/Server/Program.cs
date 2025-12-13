using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services;
using Shared.Services;
using DotNetEnv;
using StackExchange.Redis;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var server = Environment.GetEnvironmentVariable("DB_SERVER");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server=tcp:{server},1433;Initial Catalog={database};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
builder.Services.AddDbContext<RealEstateDbContext>(options =>
    options.UseSqlServer(connectionString));


var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST") ?? "localhost";
var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT") ?? "6379";

var redisConnection = ConnectionMultiplexer.Connect($"{redisHost}:{redisPort}");
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

builder.Services.AddScoped<IListingService, ListingService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
