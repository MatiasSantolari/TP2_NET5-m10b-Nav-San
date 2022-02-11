using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Especialidades : Page
    {
        private EspecialidadLogic _logic;

        public EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
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
            Persona p = (Persona)Session["USUARIO"];
            if (p == null)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.ValidationActionPanel.Visible = false;
                this.Menu2.Visible = false;
            }
            else if(p.TipoPersona.ToString() == "Alumno" || p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

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

        private Especialidad Entity { get; set; }
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
            this.descTextBox.Text = this.Entity.DescEspecialidad;
        }

        protected void editarlinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                ValidacionBorrado.Visible = false;
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Especialidad espec)
        {
            espec.DescEspecialidad = this.descTextBox.Text;
        }

        private void SaveEntity(Especialidad espec)
        {
            this.Logic.Save(espec);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (descTextBox.Text == "")
            { Label1.Visible = true; }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.modificacion:
                        this.Entity = new Especialidad();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        Entity.DescEspecialidad = this.descTextBox.Text;
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    case FormModes.alta:
                        this.Entity = new Especialidad();
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
        }

        private void EnableForm(bool enable)
        {
            this.descTextBox.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                ValidacionBorrado.Visible = false;
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);

                //
                Validaciones val = new Validaciones();
                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad es = new Especialidad();
                es = el.GetOne(SelectedID);
                if (val.ValidaBorradoEspecialidad(es) == true) { ValidacionBorrado.Visible = true; }
                else
                {
                    ValidacionBorrado.Visible = false;
                    this.LoadForm(this.SelectedID);
                }
                //
            }
        }

        private void DeleteEntity(int ID)
        {
            try
            {
                this.Logic.Delete(ID);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex.Message);
            }

        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            ValidacionBorrado.Visible = false;
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
            this.FormMode = FormModes.alta;
            this.ClearForm();
            this.EnableForm(true);
        }


        private void ClearForm()
        {
            this.descTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
            this.Label1.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }


    }
}