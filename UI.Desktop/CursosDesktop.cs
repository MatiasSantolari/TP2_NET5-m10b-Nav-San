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
    public partial class CursosDesktop : ApplicationForm
    {
        public Curso CursoActual { get; set; }
        public CursosDesktop()
        {
            InitializeComponent();
            MateriaLogic ml = new MateriaLogic();
            cbxMateria.DataSource = ml.GetAll();
            cbxMateria.DisplayMember = "DescMateria";
            cbxMateria.ValueMember = "ID";
            ComisionLogic cl = new ComisionLogic();
            cbxComision.DataSource = cl.GetAll();
            cbxComision.DisplayMember = "DescComision";
            cbxComision.ValueMember = "ID";
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursosDesktop(int ID, ModoForm modo) : this()
        {
            CursoLogic cur = new CursoLogic();

            Modo = modo;

            CursoActual = cur.GetOne(ID);
            MapearDeDatos();
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            cbxMateria.SelectedValue = this.CursoActual.IDMateria;
            cbxComision.SelectedValue = this.CursoActual.IDComision;
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
                    Curso Us = new Curso();
                    CursoActual = Us;
                    int id = 0;
                    this.CursoActual.ID = id;
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                    this.CursoActual.IDComision = int.Parse(cbxComision.SelectedValue.ToString());
                    this.CursoActual.IDMateria = int.Parse(cbxMateria.SelectedValue.ToString());
                    CursoActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Curso Uss = new Curso();
                    CursoActual = Uss;
                    this.CursoActual.ID = int.Parse(this.txtID.Text);
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                    this.CursoActual.IDComision = int.Parse(cbxComision.SelectedValue.ToString());
                    this.CursoActual.IDMateria = int.Parse(cbxMateria.SelectedValue.ToString());
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cu = new CursoLogic();

            if (Modo == ModoForm.Baja)
            {
                List<Docente_Curso> dcs = cu.GetDocentesCurso(CursoActual.ID);

                if (dcs.Count != 0)
                {
                    this.Notificar("Debe eliminar la relacion que tiene este curso con el docente que lo da", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cu.Save(CursoActual);
                }
            }
            else
            {
                cu.Save(CursoActual);
            }
        }

        public override bool Validar()
        {

            bool b3 = string.IsNullOrEmpty(this.txtAnio.Text);
            bool b4 = string.IsNullOrEmpty(this.txtCupo.Text);

            if (b3 == false && b4 == false)
            {
                return true;
            }
            else
            {
                this.Notificar("Por favor, rellenar los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool b = this.Validar();
            if (b == true)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
