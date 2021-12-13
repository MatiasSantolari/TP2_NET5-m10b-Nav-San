<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Docentes_Cursos.aspx.cs" Inherits="UI.Web.Docentes_Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
        
                <br />
                <asp:Label ID="DocenteLabel" runat="server" Text="Docente: "></asp:Label>
                <asp:DropDownList ID="DocenteDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDocente" runat="server" ControlToValidate="DocenteDropDown" ErrorMessage="Seleccione un docente" ForeColor="Red" ToolTip="No seleccionó un docente" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                <br />
                 <asp:Label ID="CursoLabel" runat="server" Text="Curso: "></asp:Label>
                <asp:DropDownList ID="CursoDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
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
            <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
                <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formActionPanel" Visible="false" runat="server">
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
