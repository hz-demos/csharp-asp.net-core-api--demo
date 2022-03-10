using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[ApiController]
[Route("/")]
public class MainController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Welcome to the todolist api! <br /> Try <a href=\"/swagger/index.html\">Swagger</a>!";
    }
}
