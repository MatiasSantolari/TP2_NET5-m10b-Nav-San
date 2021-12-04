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
    public partial class PlanForm : Form
    {
        public PlanForm()
        {

            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                PlanLogic mat = new PlanLogic();
                this.dgvPlanes.DataSource = mat.GetAll();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar la lista de planes");
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", fe);
                throw ExcepcionManejada;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop mat = new PlanDesktop(ModoForm.Alta);
            mat.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop mat = new PlanDesktop(id, ModoForm.Modificacion);
            mat.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop mat = new PlanDesktop(id, ModoForm.Baja);
            mat.ShowDialog();
            this.Listar();
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

    }
}
