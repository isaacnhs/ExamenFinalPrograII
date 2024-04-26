<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="AgregarCasa.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Casa.AgregarCasa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-6">
                <h2 class="text-center mb-4">Agregar Casa</h2>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                <div class="mb-3">
                    <label for="txtDireccion" class="form-label">Dirección:</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCiudad" class="form-label">Ciudad:</label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
