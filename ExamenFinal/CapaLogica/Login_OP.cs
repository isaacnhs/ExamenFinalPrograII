using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenFinal.CapaLogica
{
    public class Login_OP
    {
        private string cadenaConexion = @"Data Source=PCISAAC-1\SQLEXPRESS;Initial Catalog=examenfinal;Integrated Security=True;";

        public string ValidarUsuario(string usuario, string contraseña)
        {
            string query = "ValidarUsuario";

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contraseña);

                    connection.Open();
                    string estado = (string)command.ExecuteScalar();

                    return estado;
                }
            }
        }
    }
}