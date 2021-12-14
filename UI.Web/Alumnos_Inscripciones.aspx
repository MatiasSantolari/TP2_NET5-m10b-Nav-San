<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumnos_Inscripciones.aspx.cs" Inherits="UI.Web.Alumnos_Inscripciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inscripciones</title>
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
        <h1 style="background-color:lightblue">Inscripciones</h1>

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
        <div align="center">
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Comision" DataField="ComisionDescripcion" />
                        <asp:BoundField HeaderText="Materia" DataField="MateriaDescripcion" />
                        <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                        <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="formActionPanel" Visible="true" runat="server">
                <asp:LinkButton ID="inscribirLinkButton" class="btn btn-success" runat="server"  ValidationGroup="vg" OnClick="inscribirLinkButton_Click">Inscribir</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>                    
            </asp:Panel>
            </div>
    </form>
</body>
</html>
