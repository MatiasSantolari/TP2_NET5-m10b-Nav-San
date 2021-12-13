using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuariosForm : Form
    {
        public int UsuarioID { get; set; }
        public UsuariosForm(int id)
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
            UsuarioID = id;
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }
        private void Lista()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Persona per = ul.GetPersona(UsuarioID);
            if (per.TipoPersona.ToString() == "Admin")
            {
                this.Listar();
            }
            else
            {
                this.Listar();
                tsbNuevo.Visible = false;
                tsbEliminar.Visible = false;

            }
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuariosDesktop ud = new UsuariosDesktop(ModoForm.Alta);
            ud.ShowDialog();
            Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuariosDesktop us = new UsuariosDesktop(id, ModoForm.Modificacion);
            us.ShowDialog();
            Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuariosDesktop us = new UsuariosDesktop(id, ModoForm.Baja);
            us.ShowDialog();
            Lista();
        }
    }
}
