using ExamenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.Interfaces
{
    public interface IDataPuesto
    {
        List<PuestoModel> ObtenerListaPuesto();
    }
}
