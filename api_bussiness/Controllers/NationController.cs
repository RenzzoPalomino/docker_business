using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_bussiness.Controllers
{
    [Route("genshin/[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        private readonly BL_Nation _nation;

        public NationController()
        {
            _nation = new BL_Nation();
        }

        [HttpGet("list")]
        public ActionResult GET_NATION()
        {
            try
            {
                var response = _nation.GET_NATIONS();
                if(response.Count == 0)
                {
                    return NotFound(new { StatusCode = 404, Message = "No se encontraron datos." });
                }
                else
                {
                    return Ok(new { StatusCode = 200, Data = response });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = $"An error occurred while processing your request. --> {ex.Message}" });
            }
        }

    }
}
