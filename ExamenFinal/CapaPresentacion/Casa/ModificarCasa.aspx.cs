using System;
using ExamenFinal.CapaLogica;
using System.Web.UI;
using ExamenFinal.CapaDatos;

namespace ExamenFinal.CapaPresentacion.Casa
{
    public partial class ModificarCasa : System.Web.UI.Page
    {
        private Casa_OP casaOP = new Casa_OP();
        private int idCasa;

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
                    idCasa = Convert.ToInt32(Request.QueryString["id"]);

                    ClsCasa casa = casaOP.ObtenerCasaPorId(idCasa);
                    if (casa != null)
                    {
                        txtDireccion.Text = casa.Direccion;
                        txtCiudad.Text = casa.Ciudad;
                        txtPrecio.Text = casa.Precio.ToString();
                    }
                    else
                    {
                        Response.Redirect("GestionCasas.aspx");
                    }
                }
                else
                {
                    Response.Redirect("GestionCasas.aspx");
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            idCasa = Convert.ToInt32(Request.QueryString["id"]);
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            decimal precio;

            if (!string.IsNullOrEmpty(txtPrecio.Text.Trim()) && decimal.TryParse(txtPrecio.Text.Trim(), out precio))
            {
                casaOP.ModificarCasa(idCasa, direccion, ciudad, precio);
                Response.Redirect("GestionCasas.aspx");
            }
            else
            {
                lblError.Text = "Ingrese un precio válido.";
            }
        }
    }
}
