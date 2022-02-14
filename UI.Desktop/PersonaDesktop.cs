﻿using System;
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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            cbxPlan.DataSource = pl.GetAll();
            cbxPlan.DisplayMember = "DescPlan";
            cbxPlan.ValueMember = "ID";

            PersonaLogic pel = new PersonaLogic();
            cbxTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TipoPersonas));
            //cbxTipoPersona.DisplayMember = "TipoPersona";
            //cbxTipoPersona.ValueMember = "ID";
            
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            PersonaLogic pl = new PersonaLogic();

            Modo = modo;
            PersonaActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public Persona PersonaActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion.ToString();
            this.txtEmail.Text = this.PersonaActual.Email.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono.ToString();
            this.txtFechaNac.Text = this.PersonaActual.FechaNac.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();

            PlanLogic pl = new PlanLogic();
            List<Plan> pla = new List<Plan>();
            pla = pl.GetAll();
            cbxPlan.DataSource = pla;
            cbxPlan.DisplayMember = "DescPlan";
            cbxPlan.ValueMember = "ID";
            this.cbxPlan.SelectedValue = PersonaActual.IdPlan;

            //cbxPlan.SelectedItem = this.PersonaActual.IdPlan;
            cbxTipoPersona.SelectedItem = this.PersonaActual.TipoPersona;

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
                    Persona p = new Persona();
                    PersonaActual = p;
                    int id = 0;
                    this.PersonaActual.ID = id;
                    this.PersonaActual.Nombre = this.txtNombre.Text;
                    this.PersonaActual.Apellido = this.txtApellido.Text;
                    this.PersonaActual.Direccion = this.txtDireccion.Text;
                    this.PersonaActual.Email = this.txtEmail.Text;
                    this.PersonaActual.Telefono = this.txtTelefono.Text;
                    this.PersonaActual.FechaNac = DateTime.Parse(this.txtFechaNac.Text);
                    this.PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                    this.PersonaActual.TipoPersona = (Persona.TipoPersonas)(this.cbxTipoPersona.SelectedValue);
                    this.PersonaActual.IdPlan = Int32.Parse(this.cbxPlan.SelectedValue.ToString());

                    if(v.ValidaPersona(PersonaActual) == true)
                    {
                        PersonaActual.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        MessageBox.Show("La persona ya existe.");
                        PersonaActual.State = BusinessEntity.States.Unmodified;
                    }
                    
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Persona pa = new Persona();
                    PersonaActual = pa;
                    this.PersonaActual.ID = int.Parse(this.txtID.Text);
                    this.PersonaActual.Nombre = this.txtNombre.Text;
                    this.PersonaActual.Apellido = this.txtApellido.Text;
                    this.PersonaActual.Direccion = this.txtDireccion.Text;
                    this.PersonaActual.Email = this.txtEmail.Text;
                    this.PersonaActual.Telefono = this.txtTelefono.Text;
                    this.PersonaActual.FechaNac = DateTime.Parse(this.txtFechaNac.Text);
                    this.PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                    this.PersonaActual.TipoPersona = (Persona.TipoPersonas)(this.cbxTipoPersona.SelectedValue);
                    this.PersonaActual.IdPlan = Int32.Parse(this.cbxPlan.SelectedValue.ToString());
                        PersonaActual.State = BusinessEntity.States.Modified;
                    
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
        }

        public override bool Validar()
        {
            bool b1 = string.IsNullOrEmpty(this.txtNombre.Text);
            bool b2 = string.IsNullOrEmpty(this.txtApellido.Text);
            bool b3 = string.IsNullOrEmpty(this.txtDireccion.Text);
            bool b4 = string.IsNullOrEmpty(this.txtEmail.Text);
            bool b5 = string.IsNullOrEmpty(this.txtTelefono.Text);
            bool b6 = string.IsNullOrEmpty(this.txtFechaNac.Text);
            bool b7 = string.IsNullOrEmpty(this.txtLegajo.Text);

            if (b1 == false && b2 == false && b3 == false && b4 == false && b5 == false && b6 == false && b7 == false)
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
            Validaciones v = new Validaciones();
            if(v.ValidaMail(this.txtEmail.Text) == true && v.ValidaInteger(this.txtTelefono.Text) == true && 
                v.ValidaFecha(this.txtFechaNac.Text) && v.ValidaInteger(this.txtLegajo.Text) == true &&
                this.Validar() == true)
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                if (v.ValidaMail(this.txtEmail.Text) == false)
                {
                    this.txtEmail.ForeColor = Color.Red;
                }
                if (v.ValidaInteger(this.txtLegajo.Text) == false)
                {
                    this.txtLegajo.ForeColor = Color.Red;
                }
                if (v.ValidaInteger(this.txtTelefono.Text) == false)
                {
                    this.txtTelefono.ForeColor = Color.Red;
                }
                if (v.ValidaFecha(this.txtFechaNac.Text) == false)
                {
                    this.txtFechaNac.ForeColor = Color.Red;
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
