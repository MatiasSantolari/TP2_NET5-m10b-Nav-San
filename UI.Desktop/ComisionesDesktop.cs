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
    public partial class ComisionesDesktop : ApplicationForm
    {
        
        public Comision ComisionActual { get; set; }
        public ComisionesDesktop()
        {
            InitializeComponent();
            cbxAnioEspecialidad.DataSource = Enum.GetValues(typeof(Comision.Anios));
            PlanLogic pl = new PlanLogic();
            cbxPlan.DataSource = pl.GetAll();
            cbxPlan.DisplayMember = "DescPlan";
            cbxPlan.ValueMember = "ID";
        }
        public ComisionesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionesDesktop(int ID, ModoForm modo) : this()
        {
            ComisionLogic comi = new ComisionLogic();

            Modo = modo;

            ComisionActual = comi.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.DescComision.ToString();
            cbxAnioEspecialidad.SelectedItem = this.ComisionActual.AnioEspecialidad;
            cbxPlan.SelectedValue = this.ComisionActual.IDPlan;

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
            Validaciones validaciones = new Validaciones();
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Comision com = new Comision();
                    ComisionActual = com;
                    int id = 0;
                    this.ComisionActual.ID = id;
                    this.ComisionActual.DescComision = this.txtDescripcion.Text;
                    this.ComisionActual.AnioEspecialidad = (Comision.Anios)(this.cbxAnioEspecialidad.SelectedValue); ;
                    this.ComisionActual.IDPlan = int.Parse(cbxPlan.SelectedValue.ToString());
                    if (validaciones.ValidaComision(ComisionActual))
                    {
                        ComisionActual.State = Comision.States.New;
                    }
                    else
                    {
                        MessageBox.Show("La comisión que desea agregar ya existe.");
                        ComisionActual.State = Comision.States.Unmodified;
                    }
                    
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Comision comi = new Comision();
                    ComisionActual = comi;
                    this.ComisionActual.ID = int.Parse(this.txtID.Text);
                    this.ComisionActual.DescComision = this.txtDescripcion.Text;
                    this.ComisionActual.AnioEspecialidad = (Comision.Anios)(this.cbxAnioEspecialidad.SelectedValue); ;
                    this.ComisionActual.IDPlan = int.Parse(cbxPlan.SelectedValue.ToString());
                    if (validaciones.ValidaComision(ComisionActual))
                    {
                        ComisionActual.State = Comision.States.Modified;
                    }
                    else
                    {
                        MessageBox.Show("La comisión que desea agregar ya existe.");
                        ComisionActual.State = Comision.States.Unmodified;
                    }

                    break;

                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic comi = new ComisionLogic();
            if (Modo == ModoForm.Baja)
            {
                List<Curso> cursos = comi.GetCursos(ComisionActual.ID);
                if (cursos.Count != 0)
                {
                    this.Notificar("Debe eliminar los cursos que se dan en esta comision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    comi.Save(ComisionActual);
                }
            }
            else
            {
                comi.Save(ComisionActual);
            }

        }
        public override bool Validar()
        {

            bool a2 = string.IsNullOrEmpty(this.txtDescripcion.Text);


            if (a2 == false)
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
