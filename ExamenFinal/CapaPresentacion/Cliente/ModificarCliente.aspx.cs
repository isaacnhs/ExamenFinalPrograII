using ExamenFinal.CapaDatos;
using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;

namespace ExamenFinal.CapaPresentacion.Cliente
{
    public partial class ModificarCliente : Page
    {
        private Cliente_OP clienteOP = new Cliente_OP();
        private string idCliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    idCliente = Request.QueryString["id"];

                    ClsCliente cliente = clienteOP.ObtenerClientePorId(idCliente);
                    if (cliente != null)
                    {
                        txtNombre.Text = cliente.Nombre;
                        txtEmail.Text = cliente.Email;
                        txtTelefono.Text = cliente.Telefono;
                    }
                    else
                    {
                        Response.Redirect("GestionClientes.aspx");
                    }
                }
                else
                {
                    Response.Redirect("GestionClientes.aspx");
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            idCliente = Request.QueryString["id"];
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(telefono))
            {
                clienteOP.ModificarCliente(idCliente, nombre, email, telefono);
                Response.Redirect("GestionClientes.aspx");
            }
            else
            {
                lblError.Text = "Todos los campos son obligatorios.";
            }
        }
    }
}
