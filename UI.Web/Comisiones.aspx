<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Comisiones</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="gridPanel" runat="server" >
                <asp:gridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                     <Columns>  
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Año especialidad" DataField="AnioEspecialidad" />
                        <asp:BoundField HeaderText="Plan" DataField="PlanDescripcion" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:gridView>
            </asp:Panel>

            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
                <asp:TextBox ID="descripcionTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion no puede estar vacía" ForeColor="Red" ToolTip="La descripcion no puede estar vacía" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año: "></asp:Label>
                <asp:TextBox ID="anioEspecialidadTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfanioEspecialidad" runat="server" ControlToValidate="anioEspecialidadTextBox"  ErrorMessage="El Año de especialidad no puede estar vacío" ForeColor="Red" ToolTip="El Año de especialidad no puede estar vacío" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rngAnio" runat="server" ControlToValidate="anioEspecialidadTextBox" Type="Integer" MinimumValue="1" MaximumValue="3000" ErrorMessage="Ingrese un año valido." ForeColor="Red" ToolTip="Ingrese un numero valido." ValidationGroup="vg"/>        
                <br />
                <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
                <asp:DropDownList ID="planDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="revPlan" runat="server" ControlToValidate="planDropDown" ErrorMessage="Seleccione un plan" ForeColor="Red" ToolTip="No seleccionó un plan" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
            </asp:Panel>
            </div>
            <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
                <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formActionPanel" Visible="false" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" class="btn btn-success" OnClick="aceptarLinkButton_Click" ValidationGroup="vg">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButtom" runat="server" class="btn btn-danger" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="ValidationActionPanel" runat="server">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" />
    </asp:Panel>
        </div>
    </form>
</body>
</html>
