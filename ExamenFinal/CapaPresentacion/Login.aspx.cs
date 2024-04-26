using ExamenFinal.CapaLogica;
using System;

namespace ExamenFinal.CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        Login_OP loginOP = new Login_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Value;
            string contraseña = txtContraseña.Value;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                mensaje.InnerText = "Por favor, complete todos los campos.";
                return;
            }

            string estado = loginOP.ValidarUsuario(usuario, contraseña);

            if (estado == "Validado")
            {
                Session["Usuario"] = usuario;
                Session["Autenticado"] = true;

                Response.Redirect("Inicio.aspx");
            }
            else
            {
                mensaje.InnerText = "Usuario o contraseña incorrectos";
            }
        }
    }
}
