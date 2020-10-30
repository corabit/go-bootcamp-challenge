using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Services;

namespace src.Controllers
{
    [ApiController]
    [Route("api/colors")]
    public class ColorController : ControllerBase
    {
        private readonly IColorService service;

        public ColorController(IColorService service)
        {
            this.service = service;
        }
        
        /// <summary>
        /// Get all colors
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/colors
        ///
        /// </remarks>
        /// <returns>List of colors</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList()
        {
            var colors = await service.GetColors();
            return Ok(colors);
        }
        

        /// <summary>
        /// Get collor by hexadecimal code
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/colors/15b01a
        ///
        /// </remarks>
        /// <param name="hex">Hexadecimal code without '#' character</param>
        /// <returns>List of colors</returns>
        /// <response code="200">Returns the color with the given hexadecimal code</response>
        /// <response code="404">If the item doesn't exists</response>
        /// <response code="400">Bad hexadecimal code length</response>
        [HttpGet]
        [Route("{hex}")]
        public async Task<IActionResult> Get([MaxLength(6), MinLength(6)] string hex)
        {
            var color = await service.GetColor(hex);
            if (color == null) {
                return NotFound();
            }
            return Ok(color);
        }

    }

}

