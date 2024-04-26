using ExamenFinal.CapaDatos;
using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Casa
{
    public partial class GestionCasas : System.Web.UI.Page
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
                CargarCasas();
            }
        }

        private void CargarCasas()
        {
            GridViewCasas.DataSource = casaOP.ObtenerCasas();
            GridViewCasas.DataBind();
        }

        protected void btnAgregarCasa_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCasa.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            idCasa = Convert.ToInt32(btnEditar.CommandArgument);

            Response.Redirect($"ModificarCasa.aspx?id={idCasa}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            idCasa = Convert.ToInt32(btnEliminar.CommandArgument);

            casaOP.BorrarCasa(idCasa);

            CargarCasas();
        }
    }
}
