using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_bussiness.Controllers
{
    [Route("genshin/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly BL_Element _element;

        public ElementController()
        {
            _element = new BL_Element();
        }

        [HttpGet("list")]
        public ActionResult GET_ELEMENT()
        {
            try
            {
                var response = _element.GET_NATIONS();
                if (response.Count == 0)
                {
                    return NotFound(new { StatusCode = 404, Message = "No se encontraron datos." });
                }
                else
                {
                    return Ok(new { StatusCode = 200, response });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = $"An error occurred while processing your request. --> {ex.Message}" });
            }
        }
    }
}
