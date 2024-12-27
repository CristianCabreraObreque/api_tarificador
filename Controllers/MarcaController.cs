using Microsoft.AspNetCore.Mvc;
using api_tarificador.Models;

namespace api_tarificador.Controllers
{
  [ApiController]

  public class MarcaController : ControllerBase
  {
    [HttpPost]
    [Route("ObtenerMarca")]
    public IActionResult ObtenerMarcas(Marca m)
    {
      return Ok(m.ObtenerMarca());
    }

    [HttpPost]
    [Route("InsertarMarca")]
    public IActionResult InsertarMarca(Marca m)
    {
      return Ok(m.InsertarMarca());
    }

    [HttpPost]
    [Route("ActualizarMarca")]
    public IActionResult ActualizarMarca(Marca m)
    {

      return Ok(m.ActualizarMarca());
    }


  }
}
