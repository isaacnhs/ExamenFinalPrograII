<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Cliente.ModificarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-6">
                <h2 class="text-center mb-4">Modificar Cliente</h2>
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
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
