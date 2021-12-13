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
        public int UsuarioID { get; set; }
        public PlanForm(int id)
        {

            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            UsuarioID = id;
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
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
                
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop mat = new PlanDesktop(ModoForm.Alta);
            mat.ShowDialog();
            this.Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop mat = new PlanDesktop(id, ModoForm.Modificacion);
            mat.ShowDialog();
            Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop mat = new PlanDesktop(id, ModoForm.Baja);
            mat.ShowDialog();
            this.Lista();
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            this.Lista();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }

    }
}
