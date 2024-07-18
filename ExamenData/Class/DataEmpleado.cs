using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenModel;
using ExamenData.Interfaces;
using ExamenData.Helpers;

namespace ExamenData.Class
{
    public class DataEmpleado : IDataEmpleado
    {
        private readonly ConnectionStrings conexiones;

        public DataEmpleado(IOptions<ConnectionStrings> options)
        {
            conexiones = options.Value;
        }

        public List<EmpleadoModel> ObtenerEmpleados()
        {
            List<EmpleadoModel> lstEmpleados = new List<EmpleadoModel>();

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spObtenerEmpleados", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpleadoModel empleado = new EmpleadoModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Fotografia = reader.GetString(reader.GetOrdinal("Fotografia")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("Apellido")),

                            Puesto = new PuestoModel()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("PuestoId")),
                                Nombre = reader.GetString(reader.GetOrdinal("Puesto"))
                            },

                            //Puesto.  = reader.GetString(reader.GetOrdinal("Puesto")),
                            FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
                            FechaContratacion = reader.GetDateTime(reader.GetOrdinal("FechaContratacion")),
                            Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                            CorreoElectronico = reader.GetString(reader.GetOrdinal("CorreoElectronico")),

                            Estado = new EstadoModel()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                                Nombre = reader.GetString(reader.GetOrdinal("Estado"))
                            },
                            //Estado = reader.GetString(reader.GetOrdinal("Estado"))
                        };
                        lstEmpleados.Add(empleado);
                    }
                }
            }

            return lstEmpleados;
        }

        public string agregarEmpleado(EmpleadoModel values)
        {
            Response reponse = new Response();
            string? resultado = string.Empty;

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spAgregarEmpleado", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                #region parametrizacion
                cmd.Parameters.AddWithValue("@Nombre", values.Nombre);
                cmd.Parameters.AddWithValue("@Fotografia", values.Fotografia == null ? string.Empty : values.Fotografia);
                cmd.Parameters.AddWithValue("@Apellido", values.Apellido);
                cmd.Parameters.AddWithValue("@PuestoId", values.Puesto.Id);
                cmd.Parameters.AddWithValue("@FechaNacimiento", values.FechaNacimiento);
                cmd.Parameters.AddWithValue("@FechaContratacion", values.FechaContratacion);
                cmd.Parameters.AddWithValue("@Direccion", values.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", values.Telefono);
                cmd.Parameters.AddWithValue("@CorreoElectronico", values.CorreoElectronico);
                cmd.Parameters.AddWithValue("@EstadoId", values.Estado.Id);
                #endregion

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    resultado = dr["resultado"].ToString();
                }
                conn.Close();

                return resultado;

            }
        }

        public string eliminarEmpleado(int EmpleadoId)
        {
            Response reponse = new Response();
            string? resultado = string.Empty;

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spEliminarEmpleado", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                #region parametrizacion
                cmd.Parameters.AddWithValue("@EmpleadoId", EmpleadoId);
                #endregion

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    resultado = dr["resultado"].ToString();
                }
                conn.Close();

                return resultado;

            }
        }

        public string actualizarEmpleado(EmpleadoModel values)
        {
            Response reponse = new Response();
            string? resultado = string.Empty;

            using (SqlConnection conn = new SqlConnection(conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("spActualizarEmpleado", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                #region parametrizacion
                cmd.Parameters.AddWithValue("@Id", values.Id);
                cmd.Parameters.AddWithValue("@Nombre", values.Nombre);
                cmd.Parameters.AddWithValue("@Fotografia", values.Fotografia == null ? string.Empty : values.Fotografia);
                cmd.Parameters.AddWithValue("@Apellido", values.Apellido);
                cmd.Parameters.AddWithValue("@PuestoId", values.Puesto.Id);
                cmd.Parameters.AddWithValue("@FechaNacimiento", values.FechaNacimiento);
                cmd.Parameters.AddWithValue("@FechaContratacion", values.FechaContratacion);
                cmd.Parameters.AddWithValue("@Direccion", values.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", values.Telefono);
                cmd.Parameters.AddWithValue("@CorreoElectronico", values.CorreoElectronico);
                cmd.Parameters.AddWithValue("@EstadoId", values.Estado.Id);
                #endregion

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    resultado = dr["resultado"].ToString();
                }
                conn.Close();

                return resultado;

            }
        }

    }
}
