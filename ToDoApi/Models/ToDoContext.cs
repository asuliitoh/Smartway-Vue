
/*

ToDoContext = Contexto de la base de datos

ToDoContext es una clase encargada de coordinar la 
funcionalidad de Entity Framework con el modelo.

Se deriva de usar Microsoft.EntityFrameworkCore.

Debe registrarse en el contenedor de inserción de
dependencias.

*/

using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}