using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Agente
{
    public partial class GestionAgentes : System.Web.UI.Page
    {
        private Agente_OP agenteOP = new Agente_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarAgentes();
            }
        }

        protected void btnAgregarAgente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAgente.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int idAgente = Convert.ToInt32(btnEditar.CommandArgument);

            Response.Redirect($"ModificarAgente.aspx?id={idAgente}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idAgente = Convert.ToInt32(btnEliminar.CommandArgument);

            agenteOP.BorrarAgente(idAgente);

            CargarAgentes();
        }

        public void CargarAgentes()
        {
            GridViewAgentes.DataSource = agenteOP.ObtenerAgentes();
            GridViewAgentes.DataBind();
        }
    }
}