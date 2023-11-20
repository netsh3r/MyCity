using Business.Model.Location;
using Business.Service.Location;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly ILocationService _locationService;

    public ImageController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [ProducesResponseType(200, Type = typeof(Image`))]
    [HttpGet, Route("GetImage/{id}")]
    public async Task<ActionResult<LocationDto>> GetLocation(long id)
    {
        try
        {
            var location = await _locationService.GetAsync(id);
            return location != null ? Ok(location) : BadRequest();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
