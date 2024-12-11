using BLL.Features.Behavior;
using BLL.Features.Heshing;
using BLL.Features.Users.RegistUser;
using BLL.Features.Users.ValidationUsers;
using BLL.Services;
using DAL.DBContext;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<RegistUserValidator>();

builder.Services.AddValidatorsFromAssembly(typeof(RegistUserComandHandler).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<RegistUserComand,bool>), typeof(ValidationBehavior<RegistUserComand,bool>));


builder.Services.AddScoped<IHeshing, Heshing>();
builder.Services.AddScoped<ISignUpServices, SignUpServices>();

//EF core builder
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=MAREK;Database=User;Trusted_Connection=True;TrustServerCertificate=true"));

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
