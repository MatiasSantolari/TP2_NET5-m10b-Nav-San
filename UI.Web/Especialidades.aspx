<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>  
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="descTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ControlToValidate="descTextBox" ErrorMessage="La descripcion no puede estar vacía" ForeColor="Red" ToolTip="La descripcion no puede estar vacía" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
            </asp:Panel>
            <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
                <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            </div>
            <asp:Panel ID="formActionPanel" Visible="false" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" >Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="ValidationActionPanel" runat="server">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
