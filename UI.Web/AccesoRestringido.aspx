<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccesoRestringido.aspx.cs" Inherits="UI.Web.AccesoRestringido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Usted no tiene acceso a esta página"></asp:Label>
        </div>
    </form>
</body>
</html>
