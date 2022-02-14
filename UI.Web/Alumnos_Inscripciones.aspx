<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Alumnos_Inscripciones.aspx.cs" Inherits="UI.Web.Alumnos_Inscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Inscripciones</h1>

        <div align="center">
            
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-responsive-lg">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre Alumno" DataField="Nombre Alumno" />
                        <asp:BoundField HeaderText="Apellido Alumno" DataField="Apellido Alumno" />
                        <asp:BoundField HeaderText="Materia" DataField="Materia" />
                        <asp:BoundField HeaderText="Comision" DataField="Comision" />
                        <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
                        <asp:BoundField HeaderText="Nota" DataField="Nota" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                </asp:GridView>
            </asp:Panel>
            </div>
            <div class="form-group">
            <asp:Panel ID="formPanel" Visible="false" runat="server">
        
                <br />
                <asp:Label ID="AlumnoLabel" runat="server" Text="Alumno: "></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:DropDownList ID="AlumnoDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <br />
                 <asp:Label ID="CursoLabel" runat="server" Text="Curso: "></asp:Label>
                 <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                 <asp:DropDownList ID="CursoDropDown" class="form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="CursoDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <br/>
                <asp:Label ID="condicionLabel" runat="server" Text="Condición: "></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="condicionTextBox" class="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="notaTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblValidacionNota" runat="server" ForeColor="Red" Text="Nota mal ingresada" Visible="False"></asp:Label>
                <br />
            </asp:Panel>
            </div>

            <div align="center">
            <asp:Panel ID="Panel2" runat="server" class="btn-group">
                <asp:LinkButton ID="LinkButton1" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="LinkButton2" class="btn btn-secondary" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="LinkButton3" class="btn btn-secondary" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
                <br />
            <asp:Panel ID="formActionPanel" Visible="False" runat="server">
                <asp:LinkButton ID="inscribirLinkButton" class="btn btn-success" runat="server"  ValidationGroup="vg" OnClick="inscribirLinkButton_Click">Aceptar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>                    
            </asp:Panel>
            <asp:Panel ID="Panel3" Visible="False" runat="server">
                <asp:LinkButton ID="LinkButton4" class="btn btn-success" runat="server"  ValidationGroup="vg" >Aceptar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="LinkButton5" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>                    
            </asp:Panel>
            </div>
</asp:Content>
