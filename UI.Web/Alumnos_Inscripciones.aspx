<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumnos_Inscripciones.aspx.cs" Inherits="UI.Web.Alumnos_Inscripciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inscripciones</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <asp:LinkButton ID="inscribirLinkButton" class="btn btn-success" runat="server"  ValidationGroup="vg" OnClick="inscribirLinkButton_Click">Inscribirse</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
          </asp:Panel>
        </div>
    </form>
</body>
</html>
