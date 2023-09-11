using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Models;
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

    [ProducesResponseType(200,Type = typeof(DataAccess.Entities.Location))]
    [HttpPost, Route("List")]
    public async Task<IEnumerable<DataAccess.Entities.Location>> List()
    {
        return await _locationService.ListAsync();
    }
    
    [ProducesResponseType(200,Type = typeof(DataAccess.Entities.Location))]
    [HttpGet, Route("GetLocation/{id}")]
    public async Task<ActionResult<DataAccess.Entities.Location>> GetLocation(long id)
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
    public async Task<ActionResult<DataAccess.Entities.Location>> CreateLocation([FromBody] LocationDto locationDto)
    {
        try
        {
            return await _locationService.CreateAsync(locationDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut, Route("UpdateLocation")]
    public async Task<ActionResult<DataAccess.Entities.Location>> UpdateLocation([FromBody] LocationDto locationDto)
    {
        try
        {
            return await _locationService.UpdateAsync(locationDto); 
        }
        
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete, Route("DeleteLocation/{id}")]
    public async Task<ActionResult<DataAccess.Entities.Location>> DeleteLocation(long id)
    {
        try
        {
            await _locationService.DeleteAsync(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}