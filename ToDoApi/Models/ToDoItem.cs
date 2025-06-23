/*

Creación del modelo ToDoItem. 
Un modelo es un conjunto de clases que representan los datos
que la aplicación administra.

Por convención, se contiene en la carpeta Models

*/

namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; } // Clave única
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public bool Done { get; set; }

}