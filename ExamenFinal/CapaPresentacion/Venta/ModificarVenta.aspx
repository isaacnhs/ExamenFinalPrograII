<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="ModificarVenta.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Venta.ModificarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-6">
                <h2 class="text-center">Modificar Venta</h2>
                
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>

                <div class="mb-3">
                    <asp:Label ID="lblAgente" runat="server" Text="Agente"></asp:Label>
                    <asp:DropDownList ID="ddlAgente" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblCasa" runat="server" Text="Casa"></asp:Label>
                    <asp:DropDownList ID="ddlCasa" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
