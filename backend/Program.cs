using backend.database;
using Microsoft.EntityFrameworkCore;
using dotenv.net;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionMySQL"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnectionMySQL"))));

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
