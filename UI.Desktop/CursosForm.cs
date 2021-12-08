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
    public partial class CursosForm : Form
    {
        public int UsuarioID { get; set; }

        public CursosForm()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public CursosForm(int id)
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            UsuarioID = id;
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
                this.Listar();
            }
        }

        public void Listar()
        {
            try
            {
                CursoLogic ul = new CursoLogic();
                this.dgvCursos.DataSource = ul.GetAll();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar la lista de cursos");
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", fe);
                throw ExcepcionManejada;
            }
        }



        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop ud = new CursosDesktop(ModoForm.Alta);
            ud.ShowDialog();
            this.Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop us = new CursosDesktop(id, ModoForm.Modificacion);
            us.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop us = new CursosDesktop(id, ModoForm.Baja);
            us.ShowDialog();
            this.Lista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
