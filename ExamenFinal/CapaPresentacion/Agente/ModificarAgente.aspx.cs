using ExamenFinal.CapaDatos;
using ExamenFinal.CapaLogica;
using System;
using System.Web.UI;

namespace ExamenFinal.CapaPresentacion.Agente
{
    public partial class ModificarAgente : System.Web.UI.Page
    {
        private Agente_OP agenteOP = new Agente_OP();
        private int idAgente;

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
                    idAgente = Convert.ToInt32(Request.QueryString["id"]);

                    ClsAgente agente = agenteOP.ObtenerAgentePorId(idAgente);
                    if (agente != null)
                    {
                        txtNombre.Text = agente.Nombre;
                        txtEmail.Text = agente.Email;
                        txtTelefono.Text = agente.Telefono;
                    }
                    else
                    {
                        Response.Redirect("GestionAgentes.aspx");
                    }
                }
                else
                {
                    Response.Redirect("GestionAgentes.aspx");
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            idAgente = Convert.ToInt32(Request.QueryString["id"]);
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(telefono))
            {
                agenteOP.ModificarAgente(idAgente, nombre, email, telefono);
                Response.Redirect("GestionAgentes.aspx");
            }
            else
            {
                lblError.Text = "Todos los campos son obligatorios.";
            }
        }
    }
}
