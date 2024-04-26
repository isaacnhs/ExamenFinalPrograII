using ExamenFinal.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExamenFinal.CapaLogica
{
    public class Venta_OP
    {
        private string cadenaConexion = @"Data Source=PCISAAC-1\SQLEXPRESS;Initial Catalog=examenfinal;Integrated Security=True;";


        public DataTable ObtenerVentas()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarVentas";
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

        public DataTable ObtenerVentaPorId(int ventaId)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "ObtenerVentaPorId";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@venta_id", ventaId);
                    conexion.Open();
                    DataTable tabla = new DataTable();
                    tabla.Load(comando.ExecuteReader());
                    return tabla;
                }
            }
        }

        public void AgregarVenta(int idAgente, int idCliente, int idCasa, DateTime fecha)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarVentas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "agregar");
                    comando.Parameters.AddWithValue("@agente_id", idAgente);
                    comando.Parameters.AddWithValue("@cliente_id", idCliente);
                    comando.Parameters.AddWithValue("@casa_id", idCasa);
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void BorrarVenta(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarVentas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "borrar");
                    comando.Parameters.AddWithValue("@venta_id", id);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ModificarVenta(int id, int idAgente, int idCliente, int idCasa, DateTime fecha)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string procedimiento = "GestionarVentas";
                using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@accion", "modificar");
                    comando.Parameters.AddWithValue("@venta_id", id);
                    comando.Parameters.AddWithValue("@agente_id", idAgente);
                    comando.Parameters.AddWithValue("@cliente_id", idCliente);
                    comando.Parameters.AddWithValue("@casa_id", idCasa);
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

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


    }
}
