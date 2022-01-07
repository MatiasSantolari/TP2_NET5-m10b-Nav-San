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
                                           join doc in docentes on u.ID equals doc.IDDocente
                                           join cur in cursos on doc.IDCurso equals cur.ID
                                           join mat in materias on cur.IDMateria equals mat.ID
                                           join comi in comisiones on cur.IDComision equals comi.ID
                                           select (u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision, doc.Cargo)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Alumno_Inscripcion";
                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Nombre Docente");
                            dataTable1.Columns.Add("Apellido Docente");
                            dataTable1.Columns.Add("Cargo");

                            foreach (var d in usu_doc)
                            {
                                dataTable1.Rows.Add(d.Nombre, d.Apellido, d.DescMateria, d.DescComision, d.Cargo);
                            }

                            this.dgvDocentes_Cursos.DataSource = dataTable1;
                            break;
                        }
                    case Persona.TipoPersonas.Docente:
                        {
                            Alumnos_InscripcionesLogic ail = new Alumnos_InscripcionesLogic();
                            UsuarioLogic usu = new UsuarioLogic();
                            CursoLogic cl = new CursoLogic();
                            MateriaLogic ml = new MateriaLogic();
                            ComisionLogic com = new ComisionLogic();


                            var usuarios = usu.GetAll();
                            var alumnos = ail.GetAll();
                            var cursos = cl.GetAll();
                            var materias = ml.GetAll();
                            var comisiones = com.GetAll();

                            var usu_alu = (from u in usuarios
                                           join usual in alumnos on u.ID equals usual.IDAlumno
                                           join cur in cursos on usual.IDCurso equals cur.ID
                                           join mat in materias on cur.IDMateria equals mat.ID
                                           join comi in comisiones on cur.IDComision equals comi.ID
                                           where u.ID == UsuarioID
                                           select (usual, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Alumno_Inscripcion";
                            dataTable1.Columns.Add("Nombre Alumno");
                            dataTable1.Columns.Add("Apellido Alumno");
                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Condicion");
                            dataTable1.Columns.Add("Nota");
                            foreach (var ua in usu_alu)
                            {
                                dataTable1.Rows.Add(ua.Nombre, ua.Apellido, ua.DescMateria, ua.DescComision, ua.usual.Condicion, ua.usual.Nota);
                            }

                            this.dgvAlumnos_Inscipciones.DataSource = dataTable1;
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
