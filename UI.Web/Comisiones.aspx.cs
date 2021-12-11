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
    public partial class Comisiones : Page
    {
        private ComisionLogic _logic;
        public Comision comision { get; set; }

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
            PlanLogic plan = new PlanLogic();
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
            if (this.planDropDown.Items.Count == 1)
            {
                this.planDropDown.DataSource = plan.GetAll();
                this.planDropDown.DataTextField = "Descripcion";
                this.planDropDown.DataValueField = "ID";
                this.planDropDown.DataBind();
            }

        }

        public ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

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


        private void LoadForm(int ID)
        {
            this.comision = this.Logic.GetOne(ID);
            this.descripcionTextBox.Text = this.comision.DescComision;
            this.anioEspecialidadTextBox.Text = this.comision.AnioEspecialidad.ToString();
            this.planDropDown.SelectedValue = this.comision.Plan.ID.ToString();

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

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;
            this.planDropDown.Enabled = enable;
        }
        private void LoadEntity(Comision comision)
        {
            comision.DescComision = this.descripcionTextBox.Text;
            comision.AnioEspecialidad = int.Parse(this.anioEspecialidadTextBox.Text);
            comision.Plan = new Plan();

            comision.Plan.ID = int.Parse(this.planDropDown.SelectedItem.Value);
        }
        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
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
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.baja;
                this.formActionPanel.Visible = true;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
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
            this.descripcionTextBox.Text = string.Empty;
            this.anioEspecialidadTextBox.Text = string.Empty;
            this.planDropDown.SelectedIndex = 0;

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
                    this.comision = new Comision();
                    this.comision.ID = this.SelectedID;
                    this.comision.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.comision);
                    this.SaveEntity(this.comision);
                    this.LoadGrid();
                    break;
                case FormModes.alta:
                    this.comision = new Comision();
                    this.LoadEntity(this.comision);
                    this.SaveEntity(this.comision);
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

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }
    }
}