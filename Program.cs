var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
<<<<<<< HEAD
//ahaa
//sdasdads
//sdsdad
//sdad/sadsadsa
//sadsad
//Tuan dep trai vai l
=======
//code moi nhat
>>>>>>> 68eb8cbd9b4433cd4756ee9956918167519d2027
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
