using ExamenData.Helpers;
using ExamenData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenModel;

namespace ExamenBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : Controller
    {
        private readonly IDataPuesto _puesto;

        private Response response = new Response();

        public PuestoController(IDataPuesto dataPuesto)
        {
            _puesto = dataPuesto;
        }


        [HttpGet]
        [Route("ObtenerPuestos")]
        public IActionResult ObtenerListaPuestos()
        {
            try
            {
                List<PuestoModel> lstEstados = _puesto.ObtenerListaPuesto();

                response.Message = "Operación Realizada Correctamente";
                response.IsBreakOperation = "false";
                response.IsCorrect = "true";
                response.TotalRegistros = lstEstados.Count;

                if (lstEstados.Count > 0)
                {
                    response.Data = new Data() { Info = new Info() { result = lstEstados } };
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsBreakOperation = "true";
                response.IsCorrect = "false";

                return Json(response);
            }
        }
    }
}
