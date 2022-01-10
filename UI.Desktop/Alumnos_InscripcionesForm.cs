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
        public int UsuarioID { get; set; }
        public Alumnos_InscripcionesForm(int id)
        {
            InitializeComponent();
            this.dgvAlumnos_Inscipciones.AutoGenerateColumns = false;
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
                                            join usual in alumnos on u.IDPersona equals usual.IDAlumno
                                            join cur in cursos on usual.IDCurso equals cur.ID
                                            join mat in materias on cur.IDMateria equals mat.ID
                                            join comi in comisiones on cur.IDComision equals comi.ID
                                            select (usual, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Alumno_Inscripcion";
                            dataTable1.Columns.Add("ID");
                            dataTable1.Columns.Add("Nombre Alumno");
                            dataTable1.Columns.Add("Apellido Alumno");
                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Condicion");
                            dataTable1.Columns.Add("Nota");
                            foreach (var ua in usu_alu)
                            {
                                dataTable1.Rows.Add(ua.usual.ID,ua.Nombre, ua.Apellido, ua.DescMateria, ua.DescComision, ua.usual.Condicion, ua.usual.Nota);
                            }

                            this.dgvAlumnos_Inscipciones.DataSource = dataTable1;
                            dgvAlumnos_Inscipciones.AllowUserToAddRows = false;
                            break;
                        }
                    case Persona.TipoPersonas.Alumno:
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
                                           join usual in alumnos on u.IDPersona equals usual.IDAlumno
                                           join cur in cursos on usual.IDCurso equals cur.ID
                                           join mat in materias on cur.IDMateria equals mat.ID
                                           join comi in comisiones on cur.IDComision equals comi.ID
                                           where u.ID == UsuarioID
                                           select (usual, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision)).ToList();

                            DataTable dataTable1 = new DataTable();
                            dataTable1.TableName = "Alumno_Inscripcion";
                            dataTable1.Columns.Add("ID");
                            dataTable1.Columns.Add("Nombre Alumno");
                            dataTable1.Columns.Add("Apellido Alumno");
                            dataTable1.Columns.Add("Materia");
                            dataTable1.Columns.Add("Comision");
                            dataTable1.Columns.Add("Condicion");
                            dataTable1.Columns.Add("Nota");
                            foreach (var ua in usu_alu)
                            {
                                dataTable1.Rows.Add(ua.usual.ID, ua.Nombre, ua.Apellido, ua.DescMateria, ua.DescComision, ua.usual.Condicion, ua.usual.Nota);
                            }

                            this.dgvAlumnos_Inscipciones.DataSource = dataTable1;
                            dgvAlumnos_Inscipciones.AllowUserToAddRows = false;
                            break;
                        }

                }
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
            this.Lista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Alumnos_InscripcionesDesktop alinsc = new Alumnos_InscripcionesDesktop(ModoForm.Alta);
            alinsc.ShowDialog();
            this.Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ind = dgvAlumnos_Inscipciones.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvAlumnos_Inscipciones.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            Alumnos_InscripcionesDesktop editar = new Alumnos_InscripcionesDesktop(ID, ModoForm.Modificacion);
            editar.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ind = dgvAlumnos_Inscipciones.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvAlumnos_Inscipciones.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            Alumnos_InscripcionesDesktop editar = new Alumnos_InscripcionesDesktop(ID, ModoForm.Baja);
            editar.ShowDialog();
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
                this.Listar();
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;

            }
        }
    }
}
