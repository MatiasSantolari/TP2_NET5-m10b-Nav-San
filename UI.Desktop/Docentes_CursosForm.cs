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
    public partial class Docentes_CursosForm : Form
    {
        public int UsuarioID { get; set; }
        public Docentes_CursosForm()
        {
            InitializeComponent();
            this.dgvDocentes_Cursos.AutoGenerateColumns = false;
        }
        public Docentes_CursosForm(int id)
        {
            InitializeComponent();
            this.dgvDocentes_Cursos.AutoGenerateColumns = false;
            UsuarioID = id;
        }
        public void Listar()
        {

            try
            {
                Docente_CursoLogic dc = new Docente_CursoLogic();
                this.dgvDocentes_Cursos.DataSource = dc.GetAll();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error al recuperar la lista DocentesCursos");
                Exception exepcionManejada = new Exception("Error al recuperar la lista de DocentesCursos");
                throw exepcionManejada;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Docentes_CursosForm_Load(object sender, EventArgs e)
        {
            this.Lista();
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
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
                dgvDocentes_Cursos.Visible = false;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Docentes_CursosDesktop dc = new Docentes_CursosDesktop(ModoForm.Alta);
            dc.ShowDialog();
            this.Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Docente_Curso)this.dgvDocentes_Cursos.SelectedRows[0].DataBoundItem).ID;
            Docentes_CursosDesktop dc = new Docentes_CursosDesktop(id, ModoForm.Modificacion);
            dc.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Docente_Curso)this.dgvDocentes_Cursos.SelectedRows[0].DataBoundItem).ID;
            Docentes_CursosDesktop dc = new Docentes_CursosDesktop(id, ModoForm.Baja);
            dc.ShowDialog();
            this.Lista();
        }
    }
}
