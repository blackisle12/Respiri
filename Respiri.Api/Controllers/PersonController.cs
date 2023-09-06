using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Respiri.Service.Interface;

namespace Respiri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;
        private readonly ILogger<PersonController> logger;

        public PersonController(IPersonService service, ILogger<PersonController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var person = await service.Get(id);

                if (person is null) return NotFound();

                return Ok(person);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "GetById unexpected error");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var people = await service.Get();

                if (people is null) return NotFound();

                return Ok(people);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get unexpected error");
                return StatusCode(500);
            }
        }

        [HttpGet("GetVersion")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetVersion()
        {
            try
            {
                return Ok($"Hello world - {Environment.Version}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "GetVersion unexpected error");
                return StatusCode(500);
            }
        }
    }
}
