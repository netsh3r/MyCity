using Microsoft.AspNetCore.Mvc;
using MyCity.Core.Models;
using MyCity.Core.Services;

namespace MyCity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet, Route("events")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EventDto>))]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
        {
            return Ok(await _eventService.ListAsync());
        }

        [HttpGet, Route("event/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Exception))]
        public async Task<ActionResult<EventDto>> GetById(long id)
        {
            try
            {
                return Ok(await _eventService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut, Route("event")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Exception))]
        public async Task<ActionResult<EventDto>> CreateEvent([FromBody] EventDto eventDto)
        {
            try
            {                
                return Ok(await _eventService.CreateAsync(eventDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("event")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Exception))]
        public async Task<ActionResult<EventDto>> UpdateEvent([FromBody] EventDto eventDto)
        {
            try
            {
                return Ok(await _eventService.UpdateAsync(eventDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("event/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Exception))]
        public async Task<ActionResult> DeleteEvent([FromBody] long eventId)
        {
            try
            {
                await _eventService.DeleteAsync(eventId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
