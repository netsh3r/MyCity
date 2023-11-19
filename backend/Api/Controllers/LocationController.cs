using Business.Model.Location;
using Business.Service.Location;
using Dto.Dal;
using Microsoft.AspNetCore.Mvc;

namespace My.City.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    
    [ProducesResponseType(200,Type = typeof(Location))]
    [HttpPost, Route("List")]
    public async Task<IEnumerable<LocationListDto>> List()
    {
        Console.WriteLine("test");
        return await _locationService.ListAsync();
    }
    
    [ProducesResponseType(200,Type = typeof(Location))]
    [HttpGet, Route("GetLocation/{id}")]
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
    
    [HttpPut, Route("CreateLocation")]
    public async Task<ActionResult<LocationDto>> CreateLocation([FromBody] LocationDto locationDto)
    {
        try
        {
            return await _locationService.CreateOrUpdateAsync(locationDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut, Route("UpdateLocation")]
    public async Task<ActionResult<LocationDto>> UpdateLocation([FromBody] LocationDto locationDto)
    {
        try
        {
            return await _locationService.CreateOrUpdateAsync(locationDto); 
        }
        
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete, Route("DeleteLocation/{id}")]
    public ActionResult DeleteLocation(long id)
    {
        try
        {
            _locationService.Delete(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}