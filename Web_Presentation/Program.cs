using App_Service_Layer.InterFaces;
using App_Service_Layer.Mapping;
using App_Service_Layer.Services.Interfaces;
using Business.Services;
using Common_Types_Layer.Interfaces.Dapper;
using Data_Access_Layer.Dapper;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Model_Layer.Entities;
//using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers()
//    .AddFluentValidation(config =>
//    {
//        config.RegisterValidatorsFromAssemblyContaining<PersonDtoValidator>();
//    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();


//string _sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(_sqlConnectionString));
string _oracleConnectionString = builder.Configuration.GetConnectionString("OracleConnection");
builder.Services.AddScoped<IDbConnection>(sp => new OracleConnection(_oracleConnectionString));
builder.Services.AddAutoMapper(typeof(PersonProfile));
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(CategoryProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
