using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly ILogger<TodoListController> _logger;

    public TodoListController(ILogger<TodoListController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Todo>> GetAll() =>
        TodoService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Todo> Get(int id)
    {
        var todo = TodoService.Get(id);

        if (todo is null)
            return NotFound();

        return todo;
    }

    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        TodoService.Add(todo);
        return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Todo todo)
    {
        if (id != todo.Id)
            return BadRequest();

        var existingTodo = TodoService.Get(id);
        if (existingTodo is null)
            return NotFound();

        TodoService.Update(todo);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = TodoService.Get(id);

        if (todo is null)
            return NotFound();

        TodoService.Delete(id);

        return NoContent();
    }
}