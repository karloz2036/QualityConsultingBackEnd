using ExamenModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenData.Interfaces;

namespace ExamenData.Class
{
    public class DataEstado : IDataEstado
    {
        private readonly ConnectionStrings conexiones;


        public DataEstado(IOptions<ConnectionStrings> options)
        {
            conexiones = options.Value;
        }

        public List<EstadoModel> ObtenerListaEstados()
        {
            List<EstadoModel> lstEstado = new List<EstadoModel>();

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spObtenerEstados", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EstadoModel Puesto = new EstadoModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        };
                        lstEstado.Add(Puesto);
                    }
                }
            }

            return lstEstado;
        }
    }
}
