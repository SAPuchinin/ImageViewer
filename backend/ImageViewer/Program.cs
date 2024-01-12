using Microsoft.EntityFrameworkCore;
using ImageViewer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ImageViewerContext>(options => options.UseSqlServer(connection));

builder.Services.AddDomain();
builder.Services.AddEFCore();
builder.Services.AddApplication();


builder.Services.AddControllers();
builder.Services.AddCors();

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

var cors = app.Configuration.GetValue<string>("App:CorsOrigins");

if(cors != null)
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(cors));

app.MapControllers();

app.Run();
