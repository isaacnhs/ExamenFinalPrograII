using ExamenFinal.CapaLogica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExamenFinal.CapaPresentacion.Venta
{
    public partial class ModificarVenta : System.Web.UI.Page
    {
        private Venta_OP ventaOP = new Venta_OP();
        int ventaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarDatosVenta();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ventaId = Convert.ToInt32(Request.QueryString["id"]);
                int agenteId = Convert.ToInt32(ddlAgente.SelectedValue);
                int clienteId = Convert.ToInt32(ddlCliente.SelectedValue);
                int casaId = Convert.ToInt32(ddlCasa.SelectedValue);
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);

                ventaOP.ModificarVenta(ventaId, agenteId, clienteId, casaId, fecha);

                Response.Redirect("GestionVentas.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al modificar la venta: " + ex.Message;
                lblError.Text = "Por favor complete todos los campos.";
            }
        }

        private void CargarDatosVenta()
        {
            ventaId = Convert.ToInt32(Request.QueryString["id"]);
            DataTable venta = ventaOP.ObtenerVentaPorId(ventaId);
            if (venta.Rows.Count > 0)
            {
                DataRow row = venta.Rows[0];
                ddlAgente.DataSource = ventaOP.ObtenerAgentes(); 
                ddlAgente.DataTextField = "Nombre";
                ddlAgente.DataValueField = "ID";
                ddlAgente.DataBind();
                ddlAgente.SelectedValue = row["AgenteID"].ToString();

                ddlCliente.DataSource = ventaOP.ObtenerClientes(); 
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataValueField = "ID";
                ddlCliente.DataBind();
                ddlCliente.SelectedValue = row["ClienteID"].ToString();

                ddlCasa.DataSource = ventaOP.ObtenerCasas(); 
                ddlCasa.DataTextField = "Direccion";
                ddlCasa.DataValueField = "ID";
                ddlCasa.DataBind();
                ddlCasa.SelectedValue = row["CasaID"].ToString();

                txtFecha.Text = Convert.ToDateTime(row["Fecha"]).ToString("yyyy-MM-dd");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionVentas.aspx");
        }
    }
}
