using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Venta
{
    public partial class GestionVentas : Page
    {
        private Venta_OP ventaOP = new Venta_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarVentas();
            }
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarVenta.aspx");
        }

        protected void btnEditarVenta_Click(object sender, EventArgs e)
        {
            Button btnEditarVenta = (Button)sender;
            int idVenta = Convert.ToInt32(btnEditarVenta.CommandArgument);

            Response.Redirect($"ModificarVenta.aspx?id={idVenta}");
        }

        protected void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            Button btnEliminarVenta = (Button)sender;
            int idVenta = Convert.ToInt32(btnEliminarVenta.CommandArgument);

            ventaOP.BorrarVenta(idVenta);

            CargarVentas();
        }

        private void CargarVentas()
        {
            GridViewVentas.DataSource = ventaOP.ObtenerVentas();
            GridViewVentas.DataBind();
        }
    }
}
