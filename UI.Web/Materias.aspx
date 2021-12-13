<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

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
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>  
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="HS Semanales" DataField="HSSemanales" />
                        <asp:BoundField HeaderText="HS Totales" DataField="HSTotales" />
                        <asp:BoundField HeaderText="Plan" DataField="PlanDescripcion" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="descripcionTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion no puede estar vacía" ForeColor="Red" ToolTip="La descripcion no puede estar vacía" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="hssemLabel" runat="server" Text="Hs Semanales: "></asp:Label>
                <asp:TextBox ID="hssemTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHssem" runat="server" ControlToValidate="hssemTextBox"  ErrorMessage="Las horas semanales de la materia no pueden estar vacías" ForeColor="Red" ToolTip="Las horas semanales de la materia no pueden estar vacías" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rngHssem" runat="server" ControlToValidate="hssemTextBox" Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Ingrese un numero entre 1 y 100 para las horas semanales." ForeColor="Red" ToolTip="Ingrese un entero entre 1 y 100 para las horas totales." ValidationGroup="vg"/>
                <br />
                <asp:Label ID="hstotLabel" runat="server" Text="Hs Totales: "></asp:Label>
                <asp:TextBox ID="hstotTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="revHstot" runat="server" ControlToValidate="hstotTextBox" ErrorMessage="Las horas totales de la materia no pueden estar vacías" ForeColor="Red" ToolTip="Las horas totales de la materia no pueden estar vacías"  ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rngHstot" runat="server" ControlToValidate="hstotTextBox" Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Ingrese un entero entre 1 y 100 para las horas totales." ForeColor="Red" ToolTip="Ingrese un entero entre 1 y 100 para las horas totales." ValidationGroup="vg"/>
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
                <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="ValidationActionPanel" runat="server">
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
