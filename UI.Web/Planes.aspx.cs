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
    public partial class Planes : System.Web.UI.Page
    {
        private PlanLogic _logic;

        public PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
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
                this.Panel1.Visible = false;
                this.gridPanel.Visible = false;
                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.ValidationActionPanel.Visible = false;
            }
            else if (p.TipoPersona.ToString() == "Alumno" || p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
        }

        private void LoadGrid()
        {
            EspecialidadLogic espec = new EspecialidadLogic();

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

            if (this.especDropDown.Items.Count == 1)
            {
                this.especDropDown.DataSource = espec.GetAll();
                this.especDropDown.DataTextField = "DescEspecialidad";
                this.especDropDown.DataValueField = "ID";
                this.especDropDown.DataBind();
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

        private Plan Entity { get; set; }

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
            this.descripcionTextBox.Text = this.Entity.DescPlan;
            this.especDropDown.SelectedValue = this.Entity.IdEspecialidad.ToString();
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

        private void LoadEntity(Plan plan)
        {
            plan.DescPlan = this.descripcionTextBox.Text;
            plan.IdEspecialidad = int.Parse(this.especDropDown.SelectedItem.Value);
        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (descripcionTextBox.Text == "" || especDropDown.SelectedValue.Equals("0"))
            { Label1.Visible = true; Label2.Visible = true; }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.modificacion:
                        this.Entity = new Plan();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        Entity.DescPlan = this.descripcionTextBox.Text;
                        Entity.IdEspecialidad = int.Parse(this.especDropDown.SelectedItem.Value);
                        //this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    case FormModes.alta:
                        this.Entity = new Plan();
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
            this.descripcionTextBox.Enabled = enable;

            this.especDropDown.Enabled = enable;
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

                //
                Validaciones val = new Validaciones();
                PlanLogic pl = new PlanLogic();
                Plan p = new Plan();
                p = pl.GetOne(SelectedID);
                if (val.ValidaBorradoPlan(p) == true) { ValidacionBorrado.Visible = true; }
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
            this.descripcionTextBox.Text = string.Empty;

            //esto no es etc
            this.especDropDown.SelectedIndex = 0;

        }
        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }
    }
}