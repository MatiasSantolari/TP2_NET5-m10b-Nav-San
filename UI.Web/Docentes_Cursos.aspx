<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Docentes_Cursos.aspx.cs" Inherits="UI.Web.Docentes_Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Docentes</title>
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
    <form id="form1" runat="server">
        <h1 style="background-color:lightblue">Docentes</h1>

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
        <div>
            <div align="center">
            <asp:Panel ID="gridPanel" runat="server" >
                <asp:gridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                     <Columns>  
                        <asp:BoundField HeaderText="Curso" DataField="CursoDescripcion" />
                         <asp:BoundField HeaderText="Docente" DataField="LegajoDocente" />
                         <asp:BoundField HeaderText="Tipo" DataField="Cargo" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:gridView>
            </asp:Panel>
            </div>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
        
                <br />
                <asp:Label ID="AlumnoLabel" runat="server" Text="Alumno: "></asp:Label>
                <asp:DropDownList ID="DocenteDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDocente" runat="server" ControlToValidate="DocenteDropDown" ErrorMessage="Seleccione un docente" ForeColor="Red" ToolTip="No seleccionó un docente" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                 <asp:Label ID="MateriaLabel" runat="server" Text="Materia: "></asp:Label>
                <asp:DropDownList ID="MateriaDropDown" class="form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="MateriaDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TipoDropDown" ErrorMessage="Seleccione un tipo de docente" ForeColor="Red" ToolTip="No seleccionó un tipo docente" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br/>
                <asp:Label ID="ComisionLabel" runat="server" Text="Comisión: "></asp:Label>
                <asp:DropDownList ID="ComisionDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCurso" runat="server" ControlToValidate="CursoDropDown" ErrorMessage="Seleccione un curso" ForeColor="Red" ToolTip="No seleccionó un curso" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                 <asp:Label ID="TipoLabel" runat="server" Text="Tipo: "></asp:Label>

                <asp:DropDownList ID="TipoDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipo" runat="server" ControlToValidate="TipoDropDown" ErrorMessage="Seleccione un tipo de docente" ForeColor="Red" ToolTip="No seleccionó un tipo docente" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
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
