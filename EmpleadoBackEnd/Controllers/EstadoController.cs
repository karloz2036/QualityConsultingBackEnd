using ExamenData.Helpers;
using ExamenData.Interfaces;
using ExamenModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {

        private readonly IDataEstado _estado;

        private Response response = new Response();

        public EstadoController(IDataEstado dataEstado)
        {
            _estado = dataEstado;
        }

        [HttpGet]
        [Route("ObtenerEstados")]
        public IActionResult ObtenerListaEstados()
        {
            try
            {
                List<EstadoModel> lstEstados = _estado.ObtenerListaEstados();

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
