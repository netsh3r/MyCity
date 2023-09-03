using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Services;

namespace MyCity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<DataAccess.Entities.Location>> Get([FromQuery(Name = "Id")] long id)
    {
        var location = await _locationService.GetAsync(id);
        return location != null ? location : NotFound();
    }
}