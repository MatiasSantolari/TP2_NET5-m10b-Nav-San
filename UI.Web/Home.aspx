<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Home</h1>

        <asp:Panel ID="Panel2" runat="server">
            <div align="right">
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" class="btn btn-danger" OnClick="btnLogout_Click" />
            </div>
        </asp:Panel>

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
                    <asp:MenuItem NavigateUrl="~/Materias.aspx" Text="Materias" Value="Materias"></asp:MenuItem>
                </Items>
            </asp:Menu>

        </asp:Panel>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="¡Bienvenido "></asp:Label>
            <asp:Label ID="nombreLabel" runat="server"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="!"></asp:Label>
        </div>
</asp:Content>
