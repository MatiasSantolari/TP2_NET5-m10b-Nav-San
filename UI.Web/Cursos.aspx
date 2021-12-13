<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="gridPanel" runat="server" >
                <asp:gridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                     <Columns>  
                        <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
                         <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                        <asp:BoundField HeaderText="Comision" DataField="ComisionDescripcion" />
                         <asp:BoundField HeaderText="Materia" DataField="MateriaDescripcion" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:gridView>
            </asp:Panel>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
        
                <asp:Label ID="anioCalendarioLabel" runat="server" Text="Año calendario: "></asp:Label>
                <asp:TextBox ID="anioCalendarioTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfanioCalendario" runat="server" ControlToValidate="anioCalendarioTextBox"  ErrorMessage="El Año calendario no puede estar vacío" ForeColor="Red" ToolTip="El Año calendario no puede estar vacío" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rnganio" runat="server" ControlToValidate="aniocalendarioTextBox" Type="Integer" MinimumValue="1900" MaximumValue="2100" ErrorMessage="Ingrese un año válido." ForeColor="Red" ToolTip="Ingrese un año válido." ValidationGroup="vg"/>

                <br />
                <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
                <asp:TextBox ID="cupoTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCupo" runat="server" ControlToValidate="CupoTextBox"  ErrorMessage="El cupo no puede estar vacio" ForeColor="Red" ToolTip="El cupo no puede estar vacio" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rngcupo" runat="server" ControlToValidate="cupoTextBox" Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Ingrese un entero entre 1 y 100 para el cupo." ForeColor="Red" ToolTip="Ingrese un entero entre 1 y 100 para el cupo." ValidationGroup="vg"/>

                <br />
                <asp:Label ID="MateriaLabel" runat="server" Text="Materia: "></asp:Label>
                <asp:DropDownList ID="MateriaDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMateria" runat="server" ControlToValidate="MateriaDropDown" ErrorMessage="Seleccione una materia" ForeColor="Red" ToolTip="No seleccionó una materia" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                 <asp:Label ID="ComisionLabel" runat="server" Text="Comision: "></asp:Label>
                <asp:DropDownList ID="ComisionDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvComision" runat="server" ControlToValidate="ComisionDropDown" ErrorMessage="Seleccione una comision" ForeColor="Red" ToolTip="No seleccionó una comision" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
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
