<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesion</title>
    <style>
        #form1 {
            display: flex;
            justify-content: center;
            align-items: center;
            width: 100%;
            height: 100vh;
        }
        #cartelErrorLabel{
            color:red;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>

</head>
<body>
    <h1 style="background-color:lightblue;">ACADEMIA</h1>

    <form id="form1" runat="server">
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
    </form>
</body>
</html>
