<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
            <Columns>  
                <asp:BoundField HeaderText="Legajo" DataField="LegajoPersona" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>    
    </asp:Panel>

    <div class="form-group">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="LegajoLabel" runat="server" Text="Legajo: "></asp:Label>
            <asp:DropDownList ID="LegajoDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="LegajoDropDown" ErrorMessage="Seleccione un legajo" ForeColor="Red" ToolTip="No seleccionó un legajo" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" ToolTip="El nombre de usuario no puede estar vacio" ValidationGroup="vg">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="HabilitadoCheckBox" class="form-control" runat="server"></asp:CheckBox>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="repetirclaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:TextBox ID="repetirclaveTextBox" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="cvClaves" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirclaveTextBox" Operator="DataTypeCheck" ErrorMessage="Las claves no coinciden" ForeColor="Red" Type="String" ToolTip="Las claves no coinciden" ValidationGroup="vg">*</asp:CompareValidator>
            <br />
        </asp:Panel>
        </div>
        <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
            <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formActionPanel" Visible="false" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="ValidationActionPanel" runat="server">
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" />
        </asp:Panel>
    </form>
</body>
</html>
