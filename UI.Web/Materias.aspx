<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Materias</title>
    <style>
        .divider{
        width:5px;
        height:auto;
        display:inline-block;
        }
    </style>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>

</head>
<body>

    <h1 style="background-color:lightblue">Materias</h1>

        <asp:Panel ID="Panel1" runat="server">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Home.aspx" Text="Home" Value="Home"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Alumnos_Inscripciones.aspx" Text="Inscripciones" Value="Inscripciones"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Comisiones.aspx" Text="Comisiones" Value="Nuevo elemento"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Cursos.aspx" Text="Cursos" Value="Cursos"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Docentes_Cursos.aspx" Text="Docentes" Value="Docentes"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Especialidades.aspx" Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Personas.aspx" Text="Datos Personales" Value="Datos Personales"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Planes.aspx" Text="Planes" Value="Planes"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Usuarios.aspx" Text="Usuario" Value="Usuario"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </asp:Panel>
    <form id="form1" runat="server">
        <div>
            <div align ="center">
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>  
                        <asp:BoundField HeaderText="Descripcion" DataField="DescMateria" />
                        <asp:BoundField HeaderText="HS Semanales" DataField="HsSemanales" />
                        <asp:BoundField HeaderText="HS Totales" DataField="HsTotales" />
                        <asp:BoundField HeaderText="Plan" DataField="IdPlan" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
            </div>
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
    </form>
</body>
</html>
