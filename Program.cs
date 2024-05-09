var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
//asdsadasdsa
//ssdfsdf
//sd
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
