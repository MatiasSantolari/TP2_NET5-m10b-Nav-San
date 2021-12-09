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
    public partial class Alumnos_InscripcionesForm : Form
    {
        public Alumnos_InscripcionesForm()
        {
            InitializeComponent();
            this.dgvAlumnos_Inscipciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                Alumnos_InscripcionesLogic alins = new Alumnos_InscripcionesLogic();
                this.dgvAlumnos_Inscipciones.DataSource = alins.GetAll();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar las inscripciones de los alumnos");
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones de los alumnos", fe);
                throw ExcepcionManejada;
            }
        }


        private void ListaAlumnos_Inscripciones_Load(object sender, EventArgs e)
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
            Alumnos_InscripcionesDesktop alinsc = new Alumnos_InscripcionesDesktop(ModoForm.Alta);
            alinsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Alumnos_Inscripciones)this.dgvAlumnos_Inscipciones.SelectedRows[0].DataBoundItem).ID;
            Alumnos_InscripcionesDesktop alinsc = new Alumnos_InscripcionesDesktop(id, ModoForm.Modificacion);
            alinsc.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Alumnos_Inscripciones)this.dgvAlumnos_Inscipciones.SelectedRows[0].DataBoundItem).ID;
            Alumnos_InscripcionesDesktop alinsc = new Alumnos_InscripcionesDesktop(id, ModoForm.Baja);
            alinsc.ShowDialog();
            this.Listar();
        }
    }
}
