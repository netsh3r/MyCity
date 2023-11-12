using Microsoft.AspNetCore.Mvc;

namespace My.City.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController: ControllerBase
{
    [HttpGet]
    public string Test()
    {
        return "test";
    }
}