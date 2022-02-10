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
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
            Business.Logic.EspecialidadLogic el = new EspecialidadLogic();
            cbxEspecialidad.DataSource = el.GetAll();
            cbxEspecialidad.DisplayMember = "DescEspecialidad";
            cbxEspecialidad.ValueMember = "ID";
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            PlanLogic pla = new PlanLogic();

            Modo = modo;
            PlanActual = pla.GetOne(ID);
            MapearDeDatos();
        }

        public Business.Entities.Plan PlanActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescPlan.Text = this.PlanActual.DescPlan.ToString();
            //this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
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
            Validaciones v = new Validaciones();
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Plan pl = new Plan();
                    PlanActual = pl;
                    int id = 0;
                    this.PlanActual.ID = id;
                    this.PlanActual.DescPlan = this.txtDescPlan.Text;
                    this.PlanActual.IdEspecialidad = Int32.Parse(this.cbxEspecialidad.SelectedValue.ToString());
                    if(v.ValidaPlan(PlanActual) == true)
                    {
                        PlanActual.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        MessageBox.Show("El plan ya existe");
                        PlanActual.State = BusinessEntity.States.Unmodified;
                    }
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Plan pll = new Plan();
                    PlanActual = pll;
                    this.PlanActual.ID = int.Parse(this.txtID.Text);
                    this.PlanActual.DescPlan = this.txtDescPlan.Text;
                    this.PlanActual.IdEspecialidad = Int32.Parse(this.cbxEspecialidad.SelectedValue.ToString());
                    if (v.ValidaPlan(PlanActual) == true)
                    {
                        PlanActual.State = BusinessEntity.States.Modified;
                    }
                    else
                    {
                        MessageBox.Show("El plan ya existe");
                        PlanActual.State = BusinessEntity.States.Unmodified;
                    }
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic us = new PlanLogic();
            us.Save(PlanActual);
        }

        public override bool Validar()
        {

            bool b2 = string.IsNullOrEmpty(this.txtDescPlan.Text);
            //bool b3 = string.IsNullOrEmpty(this.txtIdEspecialidad.Text);

            if (b2 == false /*&& b3 == false*/)
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
