<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="AgregarAgente.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Agente.AgregarAgente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenido específico de la página de agregar agente -->
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-6">
                <h2 class="text-center mb-4">Agregar Agente</h2>
                                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Teléfono:</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
