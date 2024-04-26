<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Menu.Master" AutoEventWireup="true" CodeBehind="GestionCasas.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Casa.GestionCasas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-lg-8">

                <div class="mb-3">
                    <asp:Button ID="btnAgregarCasa" runat="server" Text="Agregar Casa" CssClass="btn btn-info" OnClick="btnAgregarCasa_Click" />
                </div>

                <h2 class="text-center">Gestión de Casas</h2>

                <asp:GridView ID="GridViewCasas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
