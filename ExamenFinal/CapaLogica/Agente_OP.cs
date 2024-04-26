using System.Data.SqlClient;
using System.Data;
using System;
using ExamenFinal.CapaDatos;

namespace ExamenFinal.CapaLogica
{
    public class Agente_OP
    {
        private string cadenaConexion = @"Data Source=PCISAAC-1\SQLEXPRESS;Initial Catalog=examenfinal;Integrated Security=True;";

        public DataTable ObtenerAgentes()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarAgentes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "consultar");
                    conexion.Open();
                    DataTable tabla = new DataTable();
                    tabla.Load(comando.ExecuteReader());
                    return tabla;
                }
            }
        }

        public ClsAgente ObtenerAgentePorId(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "ObtenerAgentePorId"; 
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@agente_id", id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        ClsAgente agente = new ClsAgente
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Email = Convert.ToString(reader["Email"]),
                            Telefono = Convert.ToString(reader["Telefono"])
                        };
                        return agente;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void AgregarAgente(string nombre, string email, string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarAgentes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "agregar");
                    comando.Parameters.AddWithValue("@agente_nombre", nombre);
                    comando.Parameters.AddWithValue("@agente_email", email);
                    comando.Parameters.AddWithValue("@agente_telefono", telefono);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void BorrarAgente(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarAgentes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "borrar");
                    comando.Parameters.AddWithValue("@agente_id", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ModificarAgente(int id, string nombre, string email, string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarAgentes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "modificar");
                    comando.Parameters.AddWithValue("@agente_id", id);
                    comando.Parameters.AddWithValue("@agente_nombre", nombre);
                    comando.Parameters.AddWithValue("@agente_email", email);
                    comando.Parameters.AddWithValue("@agente_telefono", telefono);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

    }

}
