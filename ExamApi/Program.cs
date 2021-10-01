using Exam.Grade;
using Exam.Grade.Repositories;
using Exam.Grade.Services;
using Microsoft.OpenApi.Models;
using Points.DataAccess;
using Points.DataAccess.Facades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Points API", Version = "v1" });
});

//builder.Services.AddSingleton(typeof(ExamContext));
builder.Services.AddSingleton(typeof(IDataAccessFacade<>), typeof(DataAccessFacade<>));

//builder.Services.AddSingleton(typeof(IRepository<,>), typeof(AccessControlRepository<>));

builder.Services.AddSingleton(typeof(IRepository<,>), typeof(AccessControlRepository<>));

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
