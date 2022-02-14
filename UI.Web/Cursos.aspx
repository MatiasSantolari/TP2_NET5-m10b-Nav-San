<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Cursos</h1>

        <div>

            <asp:Panel ID="gridPanel" runat="server" >
                <div align="center">
                <asp:gridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                     <Columns> 
                         <asp:BoundField HeaderText="Materia" DataField="Materia" />
                         <asp:BoundField HeaderText="Comision" DataField="Comision" />
                         <asp:BoundField HeaderText="Año Calendario" DataField="Anio" />
                         <asp:BoundField HeaderText="Cupo" DataField="Cupo" />               
                         <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:gridView>
                </div>
            </asp:Panel>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
        
                <asp:Label ID="anioCalendarioLabel" runat="server" Text="Año calendario: "></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="anioCalendarioTextBox" class="form-control" runat="server"></asp:TextBox>

                <asp:Label ID="lblValidacionAño" runat="server" ForeColor="Red" Text="Año mal ingresado" Visible="False"></asp:Label>

                <br />
                <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="cupoTextBox" class="form-control" runat="server"></asp:TextBox>

                <asp:Label ID="lblValidacionCupo" runat="server" ForeColor="Red" Text="Cupo mal ingresado" Visible="False"></asp:Label>

                <br />
                <asp:Label ID="MateriaLabel" runat="server" Text="Materia: "></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:DropDownList ID="MateriaDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <br />
                 <asp:Label ID="ComisionLabel" runat="server" Text="Comision: "></asp:Label>
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:DropDownList ID="ComisionDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="ValidacionBorrado" runat="server" ForeColor="Red" Text="No se puede eliminar el registro seleccionado" Visible="False"></asp:Label>
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
</asp:Content>
