using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModel
{
    public class PuestoModel
    {

        public PuestoModel()
        {
            Id = 0;
            Nombre = string.Empty;

        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
