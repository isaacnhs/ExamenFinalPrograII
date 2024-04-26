using ExamenFinal.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExamenFinal.CapaLogica
{
    public class Casa_OP
    {
        private string cadenaConexion = @"Data Source=PCISAAC-1\SQLEXPRESS;Initial Catalog=examenfinal;Integrated Security=True;";

        public DataTable ObtenerCasas()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarCasas";
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

        public ClsCasa ObtenerCasaPorId(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "ObtenerCasaPorId";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@casa_id", id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        ClsCasa casa = new ClsCasa
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Direccion = Convert.ToString(reader["Direccion"]),
                            Ciudad = Convert.ToString(reader["Ciudad"]),
                            Precio = Convert.ToDecimal(reader["Precio"])
                        };
                        return casa;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void AgregarCasa(string direccion, string ciudad, decimal precio)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarCasas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "agregar");
                    comando.Parameters.AddWithValue("@casa_direccion", direccion);
                    comando.Parameters.AddWithValue("@casa_ciudad", ciudad);
                    comando.Parameters.AddWithValue("@casa_precio", precio);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void BorrarCasa(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarCasas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "borrar");
                    comando.Parameters.AddWithValue("@casa_id", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ModificarCasa(int id, string direccion, string ciudad, decimal precio)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarCasas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "modificar");
                    comando.Parameters.AddWithValue("@casa_id", id);
                    comando.Parameters.AddWithValue("@casa_direccion", direccion);
                    comando.Parameters.AddWithValue("@casa_ciudad", ciudad);
                    comando.Parameters.AddWithValue("@casa_precio", precio);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
