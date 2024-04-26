<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="GestionClientes.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Cliente.GestionClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-8">

                <div class="mb-3">
                    <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" CssClass="btn btn-info" OnClick="btnAgregarCliente_Click" />
                </div>

                <h2 class="text-center">Gestión de Clientes</h2>

                <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary btn-sm" OnClick="btnEditar_Click" CommandArgument='<%# Eval("ID") %>' />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
