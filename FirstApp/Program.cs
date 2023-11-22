using FirstApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FirstApp.Services;
using FirstApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(AppStoreDatabaseSettings)));

builder.Services.AddSingleton<IAppStoreDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<AppStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("AppStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITravellingCarService, TravellingCarService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();