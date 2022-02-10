<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h1 style="background-color:lightblue;">ACADEMIA</h1>
            <div align="center">
                <asp:Label ID="usuarioLabel" runat="server" Text="Ingresar Usuario: "></asp:Label>
                <br />
                <asp:TextBox ID="usuarioTextBox" runat="server"></asp:TextBox>
            

                 <br />
                <asp:Label ID="contraseniaLabel" runat="server" Text="Ingresar contrasenia: "></asp:Label>
                <br />
                <asp:TextBox ID="contraseniaTextBox" runat="server" type ="password"></asp:TextBox>
            
                <br />
            

                <br />
                <asp:Button ID="ingresarButton" class="btn btn-success" runat="server" Text="Ingresar" OnClick="ingresarButton_Click" />
                <br />
                <br /> 
                <asp:Label ID="mensajeLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            <asp:Panel ID="ValidationActionPanel" runat="server">
            
            </asp:Panel>
</asp:Content>
