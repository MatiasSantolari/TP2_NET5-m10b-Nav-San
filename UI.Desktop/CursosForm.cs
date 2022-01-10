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
                this.Listar();
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
            }
        }

        public void Listar()
        {
            try
            {
                CursoLogic ul = new CursoLogic();
                MateriaLogic ml = new MateriaLogic();
                ComisionLogic cl = new ComisionLogic();

                var cursos = ul.GetAll();
                var materias = ml.GetAll();
                var comisiones = cl.GetAll();

                var cur = (from c in cursos
                           join m in materias on c.IDMateria equals m.ID
                           join com in comisiones on c.IDComision equals com.ID
                           select (c.ID ,m.DescMateria, com.DescComision, c.AnioCalendario, c.Cupo)).ToList();

                DataTable dataTable = new DataTable();
                dataTable.TableName = "Curso";
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Materia");
                dataTable.Columns.Add("Comision");
                dataTable.Columns.Add("Anio");
                dataTable.Columns.Add("Cupo");

                foreach(var c in cur)
                {
                    dataTable.Rows.Add(c.ID, c.DescMateria, c.DescComision, c.AnioCalendario, c.Cupo);
                }

                this.dgvCursos.DataSource = dataTable;
                dgvCursos.AllowUserToAddRows = false;

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
            int ind = dgvCursos.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvCursos.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            CursosDesktop editar = new CursosDesktop(ID, ModoForm.Modificacion);
            editar.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ind = dgvCursos.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvCursos.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            CursosDesktop eliminar = new CursosDesktop(ID, ModoForm.Baja);
            eliminar.ShowDialog();
            this.Lista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursosForm_Load(object sender, EventArgs e)
        {
            this.Lista();
        }
    }
}
