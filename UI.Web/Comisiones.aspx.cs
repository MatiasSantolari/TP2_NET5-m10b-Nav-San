using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

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
            Persona p = (Persona)Session["USUARIO"];

            if (p == null)
            {
                this.Panel1.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.gridPanel.Visible = false;
                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
                this.ValidationActionPanel.Visible = false;
            }
            else if (p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
            else if (p.TipoPersona.ToString() == "Alumno")
            {
                this.gridActionsPanel.Visible = false;
                this.gridPanel.Visible = false;
            }
        }

        private void LoadGrid()
        {
            ComisionLogic cl = new ComisionLogic();
            PlanLogic pl = new PlanLogic();

            var comisiones = cl.GetAll();
            var planes = pl.GetAll();

            var compl = (from c in comisiones
                         join p in planes on c.IDPlan equals p.ID
                         select (c.ID, c.DescComision, c.AnioEspecialidad, p.DescPlan)).ToList();

            DataTable dataTable = new DataTable();
            dataTable.TableName = "Comision";
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");
            dataTable.Columns.Add("Anio");
            dataTable.Columns.Add("Plan");
            foreach (var c in compl)
            {
                dataTable.Rows.Add(c.ID, c.DescComision, c.AnioEspecialidad, c.DescPlan);
            }

            this.gridView.DataSource = dataTable;
            this.gridView.DataBind();
            if (this.planDropDown.Items.Count == 1)
            {
                this.planDropDown.DataSource = pl.GetAll();
                this.planDropDown.DataTextField = "DescPlan";
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
            this.SelectedID = int.Parse((string)this.gridView.SelectedValue);
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
            this.planDropDown.SelectedValue = this.comision.IDPlan.ToString();

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

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;
            this.planDropDown.Enabled = enable;
        }
        private void LoadEntity(Comision comision)
        {
            comision.DescComision = this.descripcionTextBox.Text;
            comision.AnioEspecialidad = (Comision.Anios)int.Parse(this.anioEspecialidadTextBox.Text);
            comision.IDPlan = int.Parse(this.planDropDown.SelectedItem.Value);
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
                ValidacionBorrado.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.baja;
                this.formActionPanel.Visible = true;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);

                //
                Validaciones val = new Validaciones();
                ComisionLogic cl = new ComisionLogic();
                Comision c = new Comision();
                c = cl.GetOne(SelectedID);
                if (val.ValidaBorradoComision(c) == true) { ValidacionBorrado.Visible = true; }
                else
                {
                    ValidacionBorrado.Visible = false;
                    this.LoadForm(this.SelectedID);
                }
                //
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
            this.anioEspecialidadTextBox.Text = string.Empty;
            this.planDropDown.SelectedIndex = 0;

        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (descripcionTextBox.Text == "" || anioEspecialidadTextBox.Text == "" || planDropDown.SelectedValue.Equals("0")) 
            { Label1.Visible = true; Label2.Visible = true; Label3.Visible = true; }
            else {
                Validaciones val = new Validaciones();
                if (val.ValidaInteger(this.anioEspecialidadTextBox.Text))
                {
                    this.lblValidacionAño.Visible = false;
                    Label1.Visible = false; Label2.Visible = false; Label3.Visible = false;
                    this.aceptarLinkButton.Visible = false;
                    this.cancelarLinkButtom.Visible = false;

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
                            comision.DescComision = this.descripcionTextBox.Text;
                            comision.AnioEspecialidad = (Comision.Anios)int.Parse(this.anioEspecialidadTextBox.Text);
                            comision.IDPlan = int.Parse(this.planDropDown.SelectedItem.Value);
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
                else
                {
                    if (val.ValidaInteger(this.anioEspecialidadTextBox.Text) == false) { this.lblValidacionAño.Visible = true; }
                    else { this.lblValidacionAño.Visible = false; }
                    EnableForm(true);

                }

            }
            
        }

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;


            EnableForm(false);
            this.lblValidacionAño.Visible = false;
            Label1.Visible = false; Label2.Visible = false; Label3.Visible = false;
            this.aceptarLinkButton.Visible = false;
            this.cancelarLinkButtom.Visible = false;
        }
    }
}