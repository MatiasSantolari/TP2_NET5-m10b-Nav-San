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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
            ModuloLogic ml = new ModuloLogic();
            cbxModulo.DataSource = ml.GetAll();
            cbxModulo.DisplayMember = "DescModulo";
            cbxModulo.ValueMember = "ID";

            UsuarioLogic ul = new UsuarioLogic();
            cbxUsuario.DataSource = ul.GetAll();
            cbxUsuario.DisplayMember = "NombreUsuario";
            cbxUsuario.ValueMember = "ID";
        }

        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();

            Modo = modo;
            ModuloUsuarioActual = mul.GetOne(ID);
            MapearDeDatos();
        }

        public ModuloUsuario ModuloUsuarioActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloUsuarioActual.ID.ToString();
            this.cbAlta.Checked = this.ModuloUsuarioActual.PermiteAlta;
            this.cbBaja.Checked = this.ModuloUsuarioActual.PermiteBaja;
            this.cbModificacion.Checked = this.ModuloUsuarioActual.PermiteModificacion;
            this.cbConsulta.Checked = this.ModuloUsuarioActual.PermiteConsulta;

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
                    ModuloUsuario mua = new ModuloUsuario();
                    ModuloUsuarioActual = mua;
                    int id = 0;
                    this.ModuloUsuarioActual.ID = id;
                    this.ModuloUsuarioActual.PermiteAlta = this.cbAlta.Checked;
                    this.ModuloUsuarioActual.PermiteBaja = this.cbBaja.Checked;
                    this.ModuloUsuarioActual.PermiteModificacion = this.cbModificacion.Checked;
                    this.ModuloUsuarioActual.PermiteConsulta = this.cbConsulta.Checked;
                    this.ModuloUsuarioActual.IdModulo = Int32.Parse(this.cbxModulo.SelectedValue.ToString());
                    this.ModuloUsuarioActual.IdUsuario = Int32.Parse(this.cbxUsuario.SelectedValue.ToString());
                    ModuloUsuarioActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    ModuloUsuario mu = new ModuloUsuario();
                    ModuloUsuarioActual = mu;
                    this.ModuloUsuarioActual.ID = int.Parse(this.txtID.Text);
                    this.ModuloUsuarioActual.PermiteAlta = this.cbAlta.Checked;
                    this.ModuloUsuarioActual.PermiteBaja = this.cbBaja.Checked;
                    this.ModuloUsuarioActual.PermiteModificacion = this.cbModificacion.Checked;
                    this.ModuloUsuarioActual.PermiteConsulta = this.cbConsulta.Checked;
                    this.ModuloUsuarioActual.IdModulo = Int32.Parse(this.cbxModulo.SelectedValue.ToString());
                    this.ModuloUsuarioActual.IdUsuario = Int32.Parse(this.cbxUsuario.SelectedValue.ToString());
                    ModuloUsuarioActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    ModuloUsuarioActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    ModuloUsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            mul.Save(ModuloUsuarioActual);
        }

        /*public override bool Validar()
        {

        }*/

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //bool b = this.Validar();
            //if (b == true)
            //{
                this.GuardarCambios();
                this.Close();
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
