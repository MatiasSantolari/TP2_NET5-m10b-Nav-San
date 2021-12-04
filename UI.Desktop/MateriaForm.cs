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
    public partial class MateriaForm : Form
    {
        public MateriaForm()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            this.dgvMaterias.DataSource = ul.GetAll();
        }
        private void MateriasForm_Load(object sender, EventArgs e)
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
            MateriaDesktop mat = new MateriaDesktop(ModoForm.Alta);
            mat.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop mat = new MateriaDesktop(id, ModoForm.Modificacion);
            mat.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop mat = new MateriaDesktop(id, ModoForm.Baja);
            mat.ShowDialog();
            this.Listar();
        }
    }
}
