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
    public partial class ModuloUsuarioForm : Form
    {
        public ModuloUsuarioForm()
        {
            InitializeComponent();
            this.dgvModulosUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            ModuloUsuarioLogic ul = new ModuloUsuarioLogic();
            this.dgvModulosUsuarios.DataSource = ul.GetAll();
        }
        private void ModuloUsuarioForm_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop mu = new ModuloUsuarioDesktop(ModoForm.Alta);
            mu.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
            ModuloUsuarioDesktop mu = new ModuloUsuarioDesktop(id, ModoForm.Modicacion);
            mu.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
            ModuloUsuarioDesktop mu = new ModuloUsuarioDesktop(id, ModoForm.Baja);
            mu.ShowDialog();
            this.Listar();
        }

    }
}
