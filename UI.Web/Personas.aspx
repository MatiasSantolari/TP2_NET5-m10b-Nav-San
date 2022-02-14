﻿<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
        <h1 style="background-color:lightblue">Datos Personales</h1>

        <div>
            <asp:Panel ID="formPanel" Visible="true" runat="server" >
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="nombreTextBox" class="form-control" runat="server" ></asp:TextBox>
                <br />
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="apellidoTextBox" class="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="emailTextBox" class="form-control" runat="server" OnTextChanged="emailTextBox_TextChanged"></asp:TextBox>
                <asp:Label ID="lblValidacionEmail" runat="server" ForeColor="Red" Text="Mail Incorrecto" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="direccionTextBox" class="form-control" runat="server"></asp:TextBox>

                <br />
                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="telefonoTextBox" class="form-control" runat="server" ></asp:TextBox>
                <br />
                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha Nacimiento: "></asp:Label>
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="fechaNacimientoTextBox" class="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblValidacionFecha" runat="server" ForeColor="Red" Text="Fecha mal ingresada" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                <asp:TextBox ID="legajoTextBox" class="form-control" runat="server"></asp:TextBox>
               
                <asp:Label ID="lblValidacionLegajo" runat="server" ForeColor="Red" Text="Legajo Incorrecto" Visible="False"></asp:Label>
               
                <br />
                 <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
                  <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                  <asp:DropDownList ID="planDropDown" class="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0" Text="--Seleccione una opción--" Enabled="True"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:Panel>
            </div>
            <div>
            <asp:Panel ID="gridActionsPanel" runat="server" class="btn-group">
                <asp:LinkButton ID="editarlinkButton" class="btn btn-secondary" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <br />
            </asp:Panel>
    
            <asp:Panel ID="formActionPanel" Visible="true" runat="server">
                <asp:LinkButton ID="aceptarLinkButton" class="btn btn-success" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="vg">Aceptar</asp:LinkButton>
                <div class="divider"></div>
                <asp:LinkButton ID="cancelarLinkButtom" class="btn btn-danger" runat="server" OnClick="cancelarLinkButtom_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="ValidationActionPanel" runat="server">
               
            </asp:Panel>
            </div>
</asp:Content>
