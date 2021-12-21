using Points.Server;
using Points.Server.Repositories;
using Points.Server.Services;
using Microsoft.OpenApi.Models;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using Points.Logger;
using Points.Entities.Models;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Points API", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Points.Api.xml");
    c.IncludeXmlComments(filePath);
});

//builder.Services.AddSingleton(typeof(ExamContext));
builder.Services.AddSingleton(typeof(IDataAccessFacade<>), typeof(DataAccessFacade<>));

//builder.Services.AddSingleton(typeof(IRepository<,>), typeof(AccessControlRepository<>));

//builder.Services.AddScoped(typeof(IRepository<,>), typeof(AccessControlRepository));
builder.Services.AddSingleton(typeof(ILogger<>), typeof(PointsLogger<>));
builder.Services.AddSingleton<PointsDbContext, PointsDbContext>();
builder.Services.AddSingleton<IAccessControlRepository, AccessControlRepository>();
builder.Services.AddSingleton<IAccessControlService, AccessControlService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Points API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
