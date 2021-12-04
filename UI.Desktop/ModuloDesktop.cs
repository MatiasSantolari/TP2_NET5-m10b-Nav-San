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
    public partial class ModuloDesktop : ApplicationForm
    {
        public ModuloDesktop()
        {
            InitializeComponent();
        }
        public ModuloDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            ModuloLogic mod = new ModuloLogic();

            Modo = modo;
            ModuloActual = mod.GetOne(ID);
            MapearDeDatos();
        }

        public Business.Entities.Modulo ModuloActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloActual.ID.ToString();
            this.txtDescripcion.Text = this.ModuloActual.DescModulo.ToString();
            this.txtEjecuta.Text = this.ModuloActual.Ejecuta.ToString();
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
                    Modulo mod = new Modulo();
                    ModuloActual = mod;
                    int id = 0;
                    this.ModuloActual.ID = id;
                    this.ModuloActual.DescModulo = this.txtDescripcion.Text;
                    this.ModuloActual.Ejecuta = this.txtEjecuta.Text;
                    ModuloActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Modulo pll = new Modulo();
                    ModuloActual = pll;
                    this.ModuloActual.ID = int.Parse(this.txtID.Text);
                    this.ModuloActual.DescModulo = this.txtDescripcion.Text;
                    this.ModuloActual.Ejecuta = this.txtEjecuta.Text;
                    ModuloActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    ModuloActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    ModuloActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloLogic us = new ModuloLogic();
            us.Save(ModuloActual);
        }

        public override bool Validar()
        {

            bool b2 = string.IsNullOrEmpty(this.txtDescripcion.Text);
            bool b3 = string.IsNullOrEmpty(this.txtEjecuta.Text);

            if (b2 == false && b3 == false)
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
