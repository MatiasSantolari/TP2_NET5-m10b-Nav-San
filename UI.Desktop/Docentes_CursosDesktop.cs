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
    public partial class Docentes_CursosDesktop : ApplicationForm
    {
        public Docentes_CursosDesktop()
        {
            InitializeComponent();
            Mostrardatos();
        }

        private void Mostrardatos()
        {

            PersonaLogic p = new PersonaLogic();
            cbxDocente.DataSource = p.GetProfesores();
            cbxDocente.DisplayMember = "Nombre";
            cbxDocente.ValueMember = "ID";

            MateriaLogic materia = new MateriaLogic();
            cbxMateria.DataSource = materia.GetAll();
            cbxMateria.DisplayMember = "DescMateria";
            cbxMateria.ValueMember = "ID";

            /*
            ComisionLogic comision = new ComisionLogic();
            cbxComision.DataSource = comision.GetAll();
            cbxComision.DisplayMember = "DescComision";
            cbxComision.ValueMember = "ID";
            */

            cbxCargo.DataSource = Enum.GetValues(typeof(Docente_Curso.cargos));
        }

        public Docentes_CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Docente_Curso DocenteCursoActual { get; set; }

        public Docentes_CursosDesktop(int id, ModoForm modo) : this()
        {
            Docente_CursoLogic dc = new Docente_CursoLogic();
            Modo = modo;

            DocenteCursoActual = dc.GetOne(id);
            this.MapearDeDatos();
        }


        public override void MapearDeDatos()
        {

            this.txtID.Text = this.DocenteCursoActual.ID.ToString();

            this.cbxDocente.SelectedItem = this.DocenteCursoActual.IDDocente;

            CursoLogic cursoData = new CursoLogic();
            Curso c = cursoData.GetOne(DocenteCursoActual.IDCurso);

            this.cbxMateria.SelectedValue = c.IDMateria;
            this.cbxComision.SelectedValue = c.IDComision;

            cbxCargo.SelectedItem = this.DocenteCursoActual.Cargo;


            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Docente_Curso dc = new Docente_Curso();
                    DocenteCursoActual = dc;
                    int id = 0;
                    this.DocenteCursoActual.ID = id;
                    this.DocenteCursoActual.IDDocente = int.Parse(cbxDocente.SelectedValue.ToString());


                    int idMateria = (int)cbxMateria.SelectedValue;
                    int idComision = (int)cbxComision.SelectedValue;


                    Docente_CursoLogic dcl = new Docente_CursoLogic();
                    this.DocenteCursoActual.IDCurso = dcl.GetCurso(idMateria, idComision).ID;

                    this.DocenteCursoActual.Cargo = (Docente_Curso.cargos)(this.cbxCargo.SelectedValue);
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Docente_Curso doceC = new Docente_Curso();
                    DocenteCursoActual = doceC;
                    DocenteCursoActual.ID = int.Parse(txtID.Text);
                    DocenteCursoActual.IDDocente = int.Parse(cbxDocente.SelectedValue.ToString());

                    int idM = (int)cbxMateria.SelectedValue;
                    int idC = (int)cbxComision.SelectedValue;


                    Docente_CursoLogic dcl1 = new Docente_CursoLogic();
                    this.DocenteCursoActual.IDCurso = dcl1.GetCurso(idM, idC).ID;

                    this.DocenteCursoActual.Cargo = (Docente_Curso.cargos)(this.cbxCargo.SelectedValue);
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    DocenteCursoActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    DocenteCursoActual.State = BusinessEntity.States.Unmodified;
                    break;

            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            Docente_CursoLogic dcl = new Docente_CursoLogic();
            if (Modo == ModoForm.Alta)
            {
                if (DocenteCursoActual.IDCurso != 0)
                {
                    dcl.Save(DocenteCursoActual);
                }
                else
                {
                    this.Notificar("No se encontro el curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dcl.Save(DocenteCursoActual);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            List<Comision> com = cl.GetComisionesXMateria(Int32.Parse(this.cbxMateria.SelectedValue.ToString()));
            if (com.Any())
            {
                cbxComision.Enabled = true;
                cbxComision.DataSource = com;
                cbxComision.DisplayMember = "DescComision";
                cbxComision.ValueMember = "ID";

            }
            else
            {
                cbxComision.Enabled = false;
            }
        }
    }
}
