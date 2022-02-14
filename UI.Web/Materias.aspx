<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Materias</h1>
        <asp:Panel ID="Panel1" runat="server">
            
        </asp:Panel>
        <div>
            <div align ="center">
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>  
                        <asp:BoundField HeaderText="Descripcion" DataField="DescMateria" />
                        <asp:BoundField HeaderText="HS Semanales" DataField="HsSemanales" />
                        <asp:BoundField HeaderText="HS Totales" DataField="HsTotales" />
                        <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
            </div>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <br />
                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="descripcionTextBox" class="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="hssemLabel" runat="server" Text="Hs Semanales: "></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="hssemTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblValidacionHsSem" runat="server" ForeColor="Red" Text="Cantidad de Horas Invalida" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="hstotLabel" runat="server" Text="Hs Totales: "></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="hstotTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblValidacionHsTot" runat="server" ForeColor="Red" Text="Cantidad de Horas Invalida" Visible="False"></asp:Label>
                <br />

                <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:DropDownList ID="planDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="ValidacionBorrado" runat="server" ForeColor="Red" Text="No se puede eliminar el registro seleccionado" Visible="False"></asp:Label>
                <br />
            </asp:Panel>
            </div>
            <div align="center">
            <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
                <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="eliminarLinkButton" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="nuevoLinkButton" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formActionPanel" Visible="false" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg">Aceptar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="ValidationActionPanel" runat="server">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" />
            </asp:Panel>
            </div>
        </div>
</asp:Content>
