using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Weaponfy.Models.DBsettings;
using Weaponfy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<WeaponfyDatabaseSettings>(
    builder.Configuration.GetSection(nameof(WeaponfyDatabaseSettings)));

builder.Services.AddSingleton<IWeaponfyDatabaseSettings>(ac =>
    ac.GetRequiredService<IOptions<WeaponfyDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("WeaponfyDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IWeaponService, WeaponService>();
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