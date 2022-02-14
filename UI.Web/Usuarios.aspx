<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h1 style="background-color:lightblue">Usuario</h1>

    <div>
        <div align="center">
        <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
            <Columns>  
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>    
    </asp:Panel>
    </div>

    <div class="form-group">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="LegajoLabel" runat="server" Text="Legajo: "></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <asp:DropDownList ID="LegajoDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" class="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="HabilitadoCheckBox" class="form-control" runat="server"></asp:CheckBox>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <asp:TextBox ID="claveTextBox" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="repetirclaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <asp:TextBox ID="repetirclaveTextBox" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
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
            <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg" >Aceptar</asp:LinkButton>
            <div class="divider"></div>
            <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="ValidationActionPanel" runat="server">
        </asp:Panel>
        </div>
        </div>
</asp:Content>
