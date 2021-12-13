<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="formPanel" Visible="true" runat="server" >
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="nombreTextBox" class="form-control" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="nombreRequerido" runat="server" ForeColor="Red" ErrorMessage="Requerido" ControlToValidate="nombreTextBox" ValidationGroup="vg"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="apellidoTextBox" class="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="apellidoRequerido" runat="server" ForeColor="Red" ErrorMessage="Requerido" ControlToValidate="apellidoTextBox" ValidationGroup="vg"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="emailTextBox" class="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="emailRequerido" runat="server" ForeColor="Red" ErrorMessage="Requerido" ControlToValidate="emailTextBox" ValidationGroup="vg" ></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="emailValidator" runat="server"  ForeColor="Red" ControlToValidate="emailTextBox" ErrorMessage="Incorrecto" ValidationExpression="^[^@]+@[^@]+\.[a-zA-Z]{2,}$" ValidationGroup="vg"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
                <asp:TextBox ID="direccionTextBox" class="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="direccionRequerido" runat="server" ForeColor="Red" ControlToValidate="direccionTextBox" ValidationGroup="vg" ErrorMessage="Requerido"></asp:RequiredFieldValidator>

                <br />
                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="telefonoTextBox" class="form-control" runat="server" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="telefonoRequerido" runat="server" ForeColor="Red" ControlToValidate="telefonoTextBox" ValidationGroup="vg" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha Nacimiento: "></asp:Label>
                <asp:TextBox ID="fechaNacimientoTextBox" class="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="fechaNacimientorRequerida" ValidationGroup="vg" ControlToValidate="fechaNacimientoTextBox" ForeColor="Red" runat="server" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                 <asp:CompareValidator id="cvlFecha" runat="server" ControlToValidate="fechaNacimientoTextBox" Type="Date" Operator="DataTypeCheck" ForeColor="Red" ErrorMessage="Ingrese una fecha válida." ValidationGroup="vg"> </asp:CompareValidator>
                <br />
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="legajoTextBox" class="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="legajoRequerido" runat="server" ForeColor="Red" ControlToValidate="legajoTextBox" ValidationGroup="vg" ErrorMessage="Requerido"></asp:RequiredFieldValidator>      
                <asp:RangeValidator ID="rngLeg" runat="server" ControlToValidate="legajoTextBox" Type="Integer" MinimumValue="1" MaximumValue="10000" ErrorMessage="Ingrese un numero de legajo valido." ForeColor="Red" ToolTip="Ingrese un numero de legajo valido." ValidationGroup="vg"/>
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
                <br />
            </asp:Panel>
    
            <asp:Panel ID="formActionPanel" Visible="true" runat="server">
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
