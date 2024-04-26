using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Cliente
{
    public partial class GestionClientes : System.Web.UI.Page
    {
        private Cliente_OP clienteOP = new Cliente_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            string idCliente = btnEditar.CommandArgument;

            Response.Redirect($"ModificarCliente.aspx?id={idCliente}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string idCliente = btnEliminar.CommandArgument;

            clienteOP.BorrarCliente(idCliente);

            CargarClientes();
        }

        public void CargarClientes()
        {
            GridViewClientes.DataSource = clienteOP.ObtenerClientes();
            GridViewClientes.DataBind();
        }
    }
}
