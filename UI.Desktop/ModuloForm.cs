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
    public partial class ModuloForm : Form
    {
        public ModuloForm()
        {
            InitializeComponent();
            this.dgvModulos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                ModuloLogic mod = new ModuloLogic();
                this.dgvModulos.DataSource = mod.GetAll();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar la lista de modulos");
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", fe);
                throw ExcepcionManejada;
            }
        }

        private void Modulos_Load(object sender, EventArgs e)
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
            ModuloDesktop mod = new ModuloDesktop(ModoForm.Alta);
            mod.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModuloDesktop mod = new ModuloDesktop(id, ModoForm.Modificacion);
            mod.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModuloDesktop mod = new ModuloDesktop(id, ModoForm.Baja);
            mod.ShowDialog();
            this.Listar();
        }
    }
}
