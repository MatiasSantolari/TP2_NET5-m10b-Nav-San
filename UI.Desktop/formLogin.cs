using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        private int _usuario_id;

        public int UsuarioID
        {
            get
            {
                return _usuario_id;
            }
            set
            {
                _usuario_id = value;
            }
        }
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();

            Usuario usuario = new Usuario();
            bool band = false;

            foreach (Usuario user in usuarios)
            {
                if ((user.NombreUsuario == txtUsuario.Text) && (user.Clave ==txtPass.Text))
                {
                    band = true;
                    usuario = user;
                }
            }

            if (band == true)
            {                
                UsuarioID = usuario.ID;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}

