using Microsoft.EntityFrameworkCore;
using MusicStore.Persistence;
using MusicStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







//COnfiguring context and connection string:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

//Registering services: lifetime services:
    //builder.Services.AddSingleton<GenreRepository>();//singleton: objetos en memoria. Utiliza la misma intancia siempre por eso no se pierde la data.
                                                     //builder.Services.AddScoped<GenreRepository>();//scoped: objetos en memoria. Utiliza la misma intancia siempre
builder.Services.AddTransient<IGenreRepository,GenreRepository>();//transaient: siempre crea una nueva instancia

//AddScoped por sesion o request
//AddTransient





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
