using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private bool Validar(string usuario, string contraseña)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                return usuarioLogic.Autenticar(usuario, contraseña);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Ingreso()

        {

            if (!string.IsNullOrEmpty(usuarioTextBox.Text) && !string.IsNullOrEmpty(contraseniaTextBox.Text))
            {

                if (this.Validar(this.usuarioTextBox.Text, this.contraseniaTextBox.Text))
                {

                    PersonaLogic personaLogic = new PersonaLogic();
                    //Persona.TipoPersonas tipoMenu = personaLogic.GetTipoPersonaByUser(this.usuarioTextBox.Text);

                    Session["USUARIO"] = personaLogic.GetOne(this.usuarioTextBox.Text, this.contraseniaTextBox.Text);
                    /*if (tipoMenu == Persona.TipoPersonas.Admin)
                    {

                        Response.Redirect("~/MenuAdministrador.aspx");

                    }
                    else if (tipoMenu == Persona.TipoPersonas.Alumno)
                    {

                        Response.Redirect("~/MenuAlumnos.aspx");
                    }
                    else if (tipoMenu == Persona.TipoPersonas.Docente)
                    {

                        Response.Redirect("~/MenuDocentes.aspx");
                    }*/
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    mensajeLabel.Text = "Usuario o contraseña incorrecto/s";
                }
            }
            else
            {
                mensajeLabel.Text = "Usuario o contraseña vacios";
            }

        }

        protected void ingresarButton_Click(object sender, EventArgs e)
        {
            Ingreso();
        }
    }
}