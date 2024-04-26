using ExamenFinal.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Agente
{
    public partial class AgregarAgente : System.Web.UI.Page
    {
        private Agente_OP agenteOP = new Agente_OP();

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
                agenteOP.AgregarAgente(nombre, email, telefono);
                Response.Redirect("GestionAgentes.aspx");
            }
            else
            {
                lblError.Text = "Todos los campos son obligatorios.";
            }
        }
    }
}