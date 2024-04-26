using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;

namespace ExamenFinal.CapaPresentacion.Venta
{
    public partial class AgregarVenta : Page
    {
        private Venta_OP ventaOP = new Venta_OP();
        private Agente_OP agenteOP = new Agente_OP();
        private Cliente_OP clienteOP = new Cliente_OP();
        private Casa_OP casaOP = new Casa_OP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autenticado"] == null || !(bool)Session["Autenticado"])
            {
                Response.Redirect("/CapaPresentacion/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarAgentes();
                CargarClientes();
                CargarCasas();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

                try
                {
                    int idAgente = Convert.ToInt32(ddlAgentes.SelectedValue);
                    int idCliente = Convert.ToInt32(ddlClientes.SelectedValue);
                    int idCasa = Convert.ToInt32(ddlCasas.SelectedValue);
                    DateTime fecha = Convert.ToDateTime(txtFecha.Text);

                    ventaOP.AgregarVenta(idAgente, idCliente, idCasa, fecha);
                    Response.Redirect("GestionVentas.aspx");
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al agregar la venta: " + ex.Message;
                    lblError.Text = "Por favor complete todos los campos.";

                }
        }

        private void CargarAgentes()
        {
            ddlAgentes.DataSource = agenteOP.ObtenerAgentes();
            ddlAgentes.DataTextField = "Nombre";
            ddlAgentes.DataValueField = "ID";
            ddlAgentes.DataBind();
        }

        private void CargarClientes()
        {
            ddlClientes.DataSource = clienteOP.ObtenerClientes();
            ddlClientes.DataTextField = "Nombre";
            ddlClientes.DataValueField = "ID";
            ddlClientes.DataBind();
        }

        private void CargarCasas()
        {
            ddlCasas.DataSource = casaOP.ObtenerCasas();
            ddlCasas.DataTextField = "Direccion";
            ddlCasas.DataValueField = "ID";
            ddlCasas.DataBind();
        }
    }
}
