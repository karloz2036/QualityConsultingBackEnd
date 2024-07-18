using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenData.Interfaces;
using ExamenModel;
using Microsoft.Extensions.Options;

namespace ExamenData.Class
{
    public class DataPuesto : IDataPuesto
    {

        private readonly ConnectionStrings conexiones;

        public DataPuesto(IOptions<ConnectionStrings> options)
        {
            conexiones = options.Value;
        }

        public List<PuestoModel> ObtenerListaPuesto()
        {
            List<PuestoModel> lstPuesto = new List<PuestoModel>();

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spObtenerPuestos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PuestoModel Puesto = new PuestoModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        };
                        lstPuesto.Add(Puesto);
                    }
                }
            }

            return lstPuesto;
        }
    }
}
