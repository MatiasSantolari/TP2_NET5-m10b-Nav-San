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
    public partial class PersonaForm : Form
    {
        public PersonaForm()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop per = new PersonaDesktop(ModoForm.Alta);
            per.ShowDialog();
            this.Listar();
        }

        private void PersonaForm_Load(object sender, EventArgs e)
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop per = new PersonaDesktop(id, ModoForm.Modificacion);
            per.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop per = new PersonaDesktop(id, ModoForm.Baja);
            per.ShowDialog();
            this.Listar();
        }
    }
}
