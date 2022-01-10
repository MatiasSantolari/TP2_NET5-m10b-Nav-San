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
                UsuarioLogic ul = new UsuarioLogic();
                Persona per = ul.GetPersona(UsuarioID);
                switch (per.TipoPersona)
                {

                    case Persona.TipoPersonas.Admin:
                        {
                            Docente_CursoLogic dcl = new Docente_CursoLogic();
                            UsuarioLogic usu = new UsuarioLogic();
                            CursoLogic cl = new CursoLogic();
                            MateriaLogic ml = new MateriaLogic();
                            ComisionLogic com = new ComisionLogic();

                            var usuarios = usu.GetAll();
                            var docentes = dcl.GetAll();
                            var cursos = cl.GetAll();
                            var materias = ml.GetAll();
                            var comisiones = com.GetAll();

                            var usu_doc = (from u in usuarios
                                           join doc in docentes on u.IDPersona equals doc.IDDocente
                                           join cur in cursos on doc.IDCurso equals cur.ID
                                           join mat in materias on cur.IDMateria equals mat.ID
                                           join comi in comisiones on cur.IDComision equals comi.ID
                                           select (doc.ID, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision, doc.Cargo)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Alumno_Inscripcion";
                            dataTable1.Columns.Add("ID");
                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Nombre Docente");
                            dataTable1.Columns.Add("Apellido Docente");
                            dataTable1.Columns.Add("Cargo");

                            foreach (var d in usu_doc)
                            {
                                dataTable1.Rows.Add(d.ID,d.DescMateria, d.DescComision, d.Nombre, d.Apellido, d.Cargo);
                            }

                            this.dgvDocentes_Cursos.DataSource = dataTable1;
                            dgvDocentes_Cursos.AllowUserToAddRows = false;
                            break;
                        }
                    case Persona.TipoPersonas.Docente:
                        {
                            Docente_CursoLogic ail = new Docente_CursoLogic();
                            UsuarioLogic usu = new UsuarioLogic();
                            CursoLogic cl = new CursoLogic();
                            MateriaLogic ml = new MateriaLogic();
                            ComisionLogic com = new ComisionLogic();


                            var usuarios = usu.GetAll();
                            var docentes = ail.GetAll();
                            var cursos = cl.GetAll();
                            var materias = ml.GetAll();
                            var comisiones = com.GetAll();

                            var usu_alu = (from u in usuarios
                                           join doc in docentes on u.IDPersona equals doc.IDDocente
                                           join cur in cursos on doc.IDCurso equals cur.ID
                                           join mat in materias on cur.IDMateria equals mat.ID
                                           join comi in comisiones on cur.IDComision equals comi.ID
                                           where u.ID == UsuarioID
                                           select (doc, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Docente_Curso";
                            dataTable1.Columns.Add("ID");

                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Nombre Docente");
                            dataTable1.Columns.Add("Apellido Docente");
                            dataTable1.Columns.Add("Cargo");
                            foreach (var ua in usu_alu)
                            {
                                dataTable1.Rows.Add(ua.doc.ID ,ua.DescMateria, ua.DescComision, ua.Nombre, ua.Apellido, ua.doc.Cargo);
                            }

                            this.dgvDocentes_Cursos.DataSource = dataTable1;
                            dgvDocentes_Cursos.AllowUserToAddRows = false;
                            break;
                        }

                }
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
            else if (per.TipoPersona.ToString() == "Docente")
            {
                this.Listar();
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
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
            int ind = dgvDocentes_Cursos.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvDocentes_Cursos.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            Docentes_CursosDesktop editar = new Docentes_CursosDesktop(ID, ModoForm.Modificacion);
            editar.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ind = dgvDocentes_Cursos.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvDocentes_Cursos.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            Docentes_CursosDesktop editar = new Docentes_CursosDesktop(ID, ModoForm.Baja);
            editar.ShowDialog();
            this.Lista();
        }
    }
}
