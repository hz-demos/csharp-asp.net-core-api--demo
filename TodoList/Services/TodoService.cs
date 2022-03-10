using TodoList.Models;

namespace TodoList.Services;

public static class TodoService
{

    static List<Todo> Todos { get; }
    static int nextId = 3;
    static TodoService()
    {
        Todos = new List<Todo>
        {
            new Todo { Id = 1, Title = "Todo1", IsCompleted = false },
            new Todo { Id = 2, Title = "Todo2", IsCompleted = false },
        };
    }

    public static List<Todo> GetAll() => Todos;
    public static Todo? Get(int id) => Todos.FirstOrDefault(p => p.Id == id);

    public static Todo Add(Todo todo)
    {
        todo.Id = nextId++;
        Todos.Add(todo);
        return todo;
    }

    public static Todo? Delete(int id)
    {
        var todo = Get(id);
        if (todo is null)
        {
            return null;
        }
        Todos.Remove(todo);
        return todo;
    }

    public static Todo? Update(Todo todo)
    {
        var index = Todos.FindIndex(p => p.Id == todo.Id);
        if (index < 0)
        {
            return null;
        }
        Todos[index] = todo;
        return Todos[index];
    }
}