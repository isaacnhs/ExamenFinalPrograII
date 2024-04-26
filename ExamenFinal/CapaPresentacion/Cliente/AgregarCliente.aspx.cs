using ExamenFinal.CapaLogica;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExamenFinal.CapaPresentacion.Cliente
{
    public partial class AgregarCliente : Page
    {
        private Cliente_OP clienteOP = new Cliente_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(telefono))
            {
                clienteOP.AgregarCliente(nombre, email, telefono);
                Response.Redirect("GestionClientes.aspx");
            }
            else
            {
                lblError.Text = "Todos los campos son obligatorios.";
            }
        }
    }
}
