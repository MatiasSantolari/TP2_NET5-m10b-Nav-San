using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Text.RegularExpressions;

namespace UI.Web
{
    public partial class Usuarios : Page
    {
        private UsuarioLogic _logic;

        public UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
            if (this.gridView.Rows.Count > 0)
            {
                this.gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void LoadGrid()
        {
            PersonaLogic personaLogic = new PersonaLogic();

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

            if (this.LegajoDropDown.Items.Count == 1)
            {
                this.LegajoDropDown.DataSource = personaLogic.GetAll();
                this.LegajoDropDown.DataTextField = "legajo";
                this.LegajoDropDown.DataValueField = "ID";
                this.LegajoDropDown.DataBind();
            }
        }

        public enum FormModes
        {
            alta,
            baja,
            modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Usuario Entity { get; set; }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;

        }

        private void LoadForm(int ID)
        {
            this.Entity = this.Logic.GetOne(ID);
            this.HabilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;

        }

        protected void editarlinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.modificacion;
                this.LoadForm(this.SelectedID);
            }
        }


        private void LoadEntity(Usuario usuario)
        {           
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.HabilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    Entity.NombreUsuario = this.nombreUsuarioTextBox.Text;
                    Entity.Clave = this.claveTextBox.Text;
                    Entity.Habilitado = this.HabilitadoCheckBox.Checked;
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }

        private void EnableForm(bool enable)
        {
            this.LegajoDropDown.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.claveLabel.Visible = enable;
            this.repetirclaveTextBox.Enabled = enable;
            this.repetirclaveLabel.Visible = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int ID)
        {
            this.Logic.Delete(ID);

        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
            this.FormMode = FormModes.alta;
            this.ClearForm();
            this.EnableForm(true);
        }


        private void ClearForm()
        {
            this.LegajoDropDown.SelectedIndex = 0;
            this.HabilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirclaveTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
        }
    }
}