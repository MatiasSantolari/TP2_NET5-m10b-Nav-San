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
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            cbxPlan.DataSource = pl.GetAll();
            cbxPlan.DisplayMember = "DescPlan";
            cbxPlan.ValueMember = "ID";
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            MateriaLogic mate = new MateriaLogic();

            Modo = modo;

            MateriaActual = mate.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescMateria.Text = this.MateriaActual.DescMateria.ToString();
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HsTotales.ToString();

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
                    Materia mat = new Materia();
                    MateriaActual = mat;
                    int id = 0;
                    this.MateriaActual.ID = id;
                    this.MateriaActual.DescMateria = this.txtDescMateria.Text;
                    this.MateriaActual.HsSemanales = int.Parse(this.txtHsSemanales.Text);
                    this.MateriaActual.HsTotales = int.Parse(this.txtHsTotales.Text);
                    this.MateriaActual.IdPlan = Int32.Parse(this.cbxPlan.SelectedValue.ToString());
                    MateriaActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Materia mate = new Materia();
                    MateriaActual = mate;
                    this.MateriaActual.ID = int.Parse(this.txtID.Text);
                    this.MateriaActual.DescMateria = this.txtDescMateria.Text;
                    this.MateriaActual.HsSemanales = int.Parse(this.txtHsSemanales.Text);
                    this.MateriaActual.HsTotales = int.Parse(this.txtHsTotales.Text);
                    this.MateriaActual.IdPlan = Int32.Parse(this.cbxPlan.SelectedValue.ToString());
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic mt = new MateriaLogic();
            mt.Save(MateriaActual);
        }

        public override bool Validar()
        {

            bool b1 = string.IsNullOrEmpty(this.txtDescMateria.Text);
            bool b2 = string.IsNullOrEmpty(this.txtHsSemanales.Text);
            bool b3 = string.IsNullOrEmpty(this.txtHsTotales.Text);

            if (b1 == false && b2 == false && b3 == false)
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

        private void cbxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
