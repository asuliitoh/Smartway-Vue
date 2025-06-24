//Incluir contexto de la base de datos y el modelo
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var nameVue = "VueApp";
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Especifica que el contexto de la base de datos utilizará una base de datos en memoria
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir Cross Origin Resource Sharing (CORS)
builder.Services.AddCors(o =>
{
    o.AddPolicy(name: nameVue,
    policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configuración de la aplicación para atender archivos estáticos y habilitar la asignación de archivos predeterminada.
app.UseDefaultFiles();
app.UseStaticFiles();

//Habilitar CORS. Si se usa JavaScript para recuperar archivos estáticos,
//debe ir antes que UseStaticFiles
app.UseCors(nameVue);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
