using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace My.City.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController: ControllerBase
{
    private readonly Test _test;

    public EventController(Test test)
    {
        _test = test;
    }

    [HttpGet]
    public string Test()
    {
        return _test.Get();
    }
}