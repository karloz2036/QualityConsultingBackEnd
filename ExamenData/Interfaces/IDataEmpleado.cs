using ExamenData.Helpers;
using ExamenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.Interfaces
{
    public interface IDataEmpleado
    {
        List<EmpleadoModel> ObtenerEmpleados();
        string agregarEmpleado(EmpleadoModel values);
        string eliminarEmpleado(int EmpleadoId);
        string actualizarEmpleado(EmpleadoModel values);
    }
}
