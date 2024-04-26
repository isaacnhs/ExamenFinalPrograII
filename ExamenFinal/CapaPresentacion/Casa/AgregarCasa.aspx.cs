using System;
using ExamenFinal.CapaLogica;
using System.Web.UI;

namespace ExamenFinal.CapaPresentacion.Casa
{
    public partial class AgregarCasa : System.Web.UI.Page
    {
        private Casa_OP casaOP = new Casa_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            decimal precio;

            if (!string.IsNullOrEmpty(txtPrecio.Text.Trim()) && decimal.TryParse(txtPrecio.Text.Trim(), out precio))
            {
                casaOP.AgregarCasa(direccion, ciudad, precio);
                Response.Redirect("GestionCasas.aspx");
            }
            else
            {
                lblError.Text = "Ingrese un precio válido.";
            }
        }
    }
}
