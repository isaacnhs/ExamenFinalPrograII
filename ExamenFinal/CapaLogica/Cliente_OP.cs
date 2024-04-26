using ExamenFinal.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExamenFinal.CapaLogica
{
    public class Cliente_OP
    {
        private string cadenaConexion = @"Data Source=PCISAAC-1\SQLEXPRESS;Initial Catalog=examenfinal;Integrated Security=True;";

        public DataTable ObtenerClientes()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarClientes";
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

        public ClsCliente ObtenerClientePorId(string id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "ObtenerClientePorId";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cliente_id", id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        ClsCliente cliente = new ClsCliente
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Email = Convert.ToString(reader["Email"]),
                            Telefono = Convert.ToString(reader["Telefono"])
                        };
                        return cliente;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void AgregarCliente(string nombre, string email, string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarClientes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "agregar");
                    comando.Parameters.AddWithValue("@cliente_nombre", nombre);
                    comando.Parameters.AddWithValue("@cliente_email", email);
                    comando.Parameters.AddWithValue("@cliente_telefono", telefono);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void BorrarCliente(string id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarClientes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "borrar");
                    comando.Parameters.AddWithValue("@cliente_id", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ModificarCliente(string id, string nombre, string email, string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarClientes";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "modificar");
                    comando.Parameters.AddWithValue("@cliente_id", id);
                    comando.Parameters.AddWithValue("@cliente_nombre", nombre);
                    comando.Parameters.AddWithValue("@cliente_email", email);
                    comando.Parameters.AddWithValue("@cliente_telefono", telefono);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
