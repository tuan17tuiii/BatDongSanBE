using BatDongSan.Converters;
using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());//add them DateConvert
});//chi co controller kh co view => web API

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
Debug.WriteLine(connectionString);

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<UserService,UserServiceImpl>();
builder.Services.AddScoped<RoleService, RoleServiceImpl>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//ssdfsdf
//sd
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}//ssdfsdf
 //sd

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
