<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Home</h1>

        <asp:Panel ID="Panel2" runat="server">
            <div align="right">
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" class="btn btn-danger" OnClick="btnLogout_Click" />
            </div>
        </asp:Panel>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="¡Bienvenido "></asp:Label>
            <asp:Label ID="nombreLabel" runat="server"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="!"></asp:Label>
        </div>
</asp:Content>
