using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModel
{
    public class EmpleadoModel
    {
        public EmpleadoModel()
        {
            Puesto = new PuestoModel();
            Estado = new EstadoModel();

        }
        public int Id { get; set; }
        public string? Fotografia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public PuestoModel Puesto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public EstadoModel Estado { get; set; }



    }
}
