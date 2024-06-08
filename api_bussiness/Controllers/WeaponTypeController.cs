using BE;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_bussiness.Controllers
{
    [Route("genshin/[controller]")]
    [ApiController]
    public class WeaponTypeController : ControllerBase
    {
        private readonly BL_Type_Weapon _wtype;

        public WeaponTypeController()
        {
            _wtype = new BL_Type_Weapon();
        }


        [HttpGet("list")]
        public ActionResult GET_TYPE_WEAPON()
        {
            try
            {
                var response = _wtype.GET_TYPE_WEAPONS();
                if (response.Count == 0)
                {
                    //return StatusCode(404, $"No se encontraron datos.");
                    return NotFound(new { StatusCode = 404, Message = "No se encontraron datos." });
                }
                else
                {
                    return Ok(new { StatusCode = 200, Data = response });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = $"An error occurred while processing your request. --> {ex.Message}" });
            }
        }

        [HttpPost("new")]
        public ActionResult NEW_TYPE_WEAPON(Type_Weapon type)
        {
            try
            {
                var response = _wtype.NEW_TYPE_WEAPON(type);
                if (response == false)
                {
                    //
                    return NotFound(new { StatusCode = 400, Message = "No se ha podido crear el elemento" });
                }
                else
                {
                    return Ok(new { StatusCode = 201, Data = response, Message ="Recurso creado exitosamente" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request. --> {ex.Message}");
            }
        }

        [HttpPut("update")]
        public ActionResult UPDATE_TYPE_WEAPON(Type_Weapon type)
        {
            try
            {
                var response = _wtype.UPDATE_TYPE_WEAPON(type);
                if (response == false)
                {
                    //
                    return NotFound(new { StatusCode = 400, Message = "No se ha podido actualizar el elemento, es posible que los parametros brindados no coincidan con algun recurso existente." });
                }
                else
                {
                    return Ok(new { StatusCode = 200, Data = response, Message = "Recurso actualizado exitosamente" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request. --> {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public ActionResult DELETE_TYPE_WEAPON(int id_type)//https://localhost:44387/genshin/WeaponType/list
        {
            try
            {
                var response = _wtype.DELETE_TYPE_WEAPON(id_type);
                if (response == false)
                {
                    //
                    return NotFound(new { StatusCode = 400, Message = "No se ha podido eliminar el elemento, es posible que los parametros brindados no coincidan con algun recurso existente." });
                }
                else
                {
                    return Ok(new { StatusCode = 200, Data = response, Message = "Recurso eliminado exitosamente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request. --> {ex.Message}");
            }
        }

    }
}
