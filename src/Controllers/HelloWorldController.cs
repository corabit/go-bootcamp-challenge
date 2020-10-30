using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/hello-world")]
    public class HelloWorldController : ControllerBase
    {
        /// <summary>
        /// Get Hello World message
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/hello-world
        ///
        /// </remarks>
        /// <returns>Hello Wold</returns>
        /// <response code="200">Returns Hello World</response>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }

}

