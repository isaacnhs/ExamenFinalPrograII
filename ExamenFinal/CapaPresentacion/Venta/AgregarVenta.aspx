<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="AgregarVenta.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Venta.AgregarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-6">
                <h2 class="text-center mb-4">Agregar Venta</h2>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                <div class="mb-3">
                    <label for="ddlAgentes" class="form-label">Agente:</label>
                    <asp:DropDownList ID="ddlAgentes" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlClientes" class="form-label">Cliente:</label>
                    <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCasas" class="form-label">Casa:</label>
                    <asp:DropDownList ID="ddlCasas" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha:</label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Venta" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
