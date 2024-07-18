using ExamenData.Helpers;
using ExamenData.Interfaces;
using ExamenModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {

        private readonly IDataEmpleado _empleado;

        private Response response = new Response();

        public EmpleadoController(IDataEmpleado dataEmpleado)
        {
            _empleado = dataEmpleado;
        }

        [HttpGet]
        [Route("ObtenerEmpleados")]
        public IActionResult ObtenerListaEmpleados()
        {
            try
            {
                List<EmpleadoModel> lstEmpleados = _empleado.ObtenerEmpleados();

                response.Message = "Operación Realizada Correctamente";
                response.IsBreakOperation = "false";
                response.IsCorrect = "true";
                response.TotalRegistros = lstEmpleados.Count;

                if (lstEmpleados.Count > 0)
                {
                    response.Data = new Data() { Info = new Info() { result = lstEmpleados } };
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

        [HttpPost]
        [Route("agregarEmpleado")]
        public IActionResult Agregar([FromBody] EmpleadoModel values)
        {
            try
            {
                string resultado = _empleado.agregarEmpleado(values);

                if (resultado == "1")
                {
                    response.Data = new Data() { Info = new Info() { result = "ok" } };
                    response.Message = "Operación Realizada Correctamente";
                    response.IsBreakOperation = "false";
                    response.IsCorrect = "true";
                    response.TotalRegistros = 1;
                }
                else
                {
                    response.Message = resultado;
                    response.IsBreakOperation = "true";
                    response.IsCorrect = "false";
                    response.TotalRegistros = 0;
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

        [HttpDelete("eliminarEmpleado/{empleadoId}")]
        public IActionResult Eliminar(int empleadoId)
        {
            try
            {
                string resultado = _empleado.eliminarEmpleado(empleadoId);

                if (resultado == "1")
                {
                    response.Data = new Data() { Info = new Info() { result = "ok" } };
                    response.Message = "Operación Realizada Correctamente";
                    response.IsBreakOperation = "false";
                    response.IsCorrect = "true";
                    response.TotalRegistros = 1;
                }
                else
                {
                    response.Message = resultado;
                    response.IsBreakOperation = "true";
                    response.IsCorrect = "false";
                    response.TotalRegistros = 0;
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

        [HttpPut]
        [Route("ActualizarEmpleado")]
        public IActionResult Actualizar([FromBody] EmpleadoModel values)
        {
            try
            {
                string resultado = _empleado.actualizarEmpleado(values);

                if (resultado == "1")
                {
                    response.Data = new Data() { Info = new Info() { result = "ok" } };
                    response.Message = "Operación Realizada Correctamente";
                    response.IsBreakOperation = "false";
                    response.IsCorrect = "true";
                    response.TotalRegistros = 1;
                }
                else
                {
                    response.Message = resultado;
                    response.IsBreakOperation = "true";
                    response.IsCorrect = "false";
                    response.TotalRegistros = 0;
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
