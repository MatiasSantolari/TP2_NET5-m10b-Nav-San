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


        private void Validar(string usuario, string contraseña)
        {

            try 
            {
                UsuarioLogic ul = new UsuarioLogic();
                List<Usuario> usuarios = ul.GetAll();

                Usuario u = new Usuario();
                bool band = false;

                foreach (Usuario user in usuarios)
                {
                    if ((user.NombreUsuario == this.usuarioTextBox.Text) && (user.Clave == this.contraseniaTextBox.Text))
                    {
                        band = true;
                        u = user;
                    }
                }

                if (band == true)
                {
                    PersonaLogic personaLogic = new PersonaLogic();
                    Session["USUARIO"] = personaLogic.GetOne(u.ID);
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    mensajeLabel.Text = "Usuario o contraseña incorrecto/s";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        protected void ingresarButton_Click(object sender, EventArgs e)
        {
            Validar(this.usuarioTextBox.Text, this.contraseniaTextBox.Text);
        }
    }
}