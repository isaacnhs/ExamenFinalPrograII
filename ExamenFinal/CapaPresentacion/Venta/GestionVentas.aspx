<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Venta.GestionVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-10">

                <div class="mb-3">
                    <asp:Button ID="btnAgregarVenta" runat="server" Text="Agregar Venta" CssClass="btn btn-info" OnClick="btnAgregarVenta_Click" />
                </div>

                <h2 class="text-center">Gestión de Ventas</h2>

                <asp:GridView ID="GridViewVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="NombreAgente" HeaderText="Agente" />
                        <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="DireccionCasa" HeaderText="Casa" />
                        <asp:BoundField DataField="PrecioCasa" HeaderText="Precio" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnEditarVenta" runat="server" Text="Editar" CssClass="btn btn-primary btn-sm" OnClick="btnEditarVenta_Click" CommandArgument='<%# Eval("ID") %>' />
                                <asp:Button ID="btnEliminarVenta" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminarVenta_Click" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
