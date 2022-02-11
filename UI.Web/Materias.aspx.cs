using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class Materias : Page
    {
        private MateriaLogic _logic;

        public MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
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
                this.Menu1.Visible = false;
            }
            else if(p.TipoPersona.ToString() == "Alumno" || p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
        }

        private void LoadGrid()
        {
            MateriaLogic mat = new MateriaLogic();
            PlanLogic pla = new PlanLogic();


            var materias = mat.GetAll();
            var planes = pla.GetAll();

            var mater = (from m in materias
                         join p in planes on m.IdPlan equals p.ID
                         select (m, p.DescPlan)).ToList();

            DataTable dataTable1 = new DataTable();
            dataTable1.TableName = "Materias";
            dataTable1.Columns.Add("ID");
            dataTable1.Columns.Add("DescMateria");
            dataTable1.Columns.Add("HsSemanales");
            dataTable1.Columns.Add("HsTotales");
            dataTable1.Columns.Add("DescPlan");
            foreach (var ma in mater)
            {
                dataTable1.Rows.Add(ma.m.ID, ma.m.DescMateria, ma.m.HsSemanales, ma.m.HsTotales, ma.DescPlan);
            }

            //var dtResultado = dataTable1.Rows.Cast<DataRow>().Where(row => !Array.TrueForAll(row.ItemArray, value => { return value.ToString().Length == 0; }));
            //dataTable1 = dtResultado.CopyToDataTable();
            this.gridView.DataSource = dataTable1;
            this.gridView.DataBind();

            if (this.planDropDown.Items.Count == 1)
            {
                this.planDropDown.DataSource = pla.GetAll();
                this.planDropDown.DataTextField = "DescPlan";
                this.planDropDown.DataValueField = "ID";
                this.planDropDown.DataBind();
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

        private Materia Entity { get; set; }

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
            this.SelectedID = int.Parse((string)this.gridView.SelectedValue);

        }
        private void LoadForm(int ID)
        {
            this.Entity = this.Logic.GetOne(ID);
            this.descripcionTextBox.Text = this.Entity.DescMateria;
            this.hssemTextBox.Text = this.Entity.HsSemanales.ToString();
            this.hstotTextBox.Text = this.Entity.HsTotales.ToString();
            this.planDropDown.SelectedValue = this.Entity.IdPlan.ToString();
        }

        protected void editarlinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                ValidacionBorrado.Visible = false;
                lblValidacionHsSem.Visible = false;
                lblValidacionHsTot.Visible = false;
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Materia materia)
        {
            materia.DescMateria = this.descripcionTextBox.Text;
            materia.HsSemanales = int.Parse(this.hssemTextBox.Text);
            materia.HsTotales = int.Parse(this.hstotTextBox.Text);
            materia.IdPlan = int.Parse(this.planDropDown.SelectedItem.Value);
        }

        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (descripcionTextBox.Text == "" || hssemTextBox.Text == "" || hstotTextBox.Text == "" || planDropDown.SelectedValue.Equals("0"))
            {
                Label1.Visible = true; Label2.Visible = true; Label3.Visible = true; Label4.Visible = true;
            }
            else
            {
                Validaciones val = new Validaciones();
                if (val.ValidaInteger(this.hssemTextBox.Text) &&
                    val.ValidaInteger(this.hstotTextBox.Text))
                {
                    this.lblValidacionHsSem.Visible = false;
                    this.lblValidacionHsTot.Visible = false;
                    Label1.Visible = false; Label2.Visible = false; Label3.Visible = false;
                    Label4.Visible = false;
                    this.aceptarLinkButton.Visible = false;
                    this.cancelarLinkButtom.Visible = false;

                    switch (this.FormMode)
                    {
                        case FormModes.baja:
                            this.DeleteEntity(this.SelectedID);
                            this.LoadGrid();
                            break;
                        case FormModes.modificacion:
                            this.Entity = new Materia();
                            this.Entity.ID = this.SelectedID;
                            this.Entity.State = BusinessEntity.States.Modified;
                            Entity.DescMateria = this.descripcionTextBox.Text;
                            Entity.HsSemanales = int.Parse(this.hssemTextBox.Text);
                            Entity.HsTotales = int.Parse(this.hstotTextBox.Text);
                            Entity.IdPlan = int.Parse(this.planDropDown.SelectedItem.Value);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            break;
                        case FormModes.alta:
                            this.Entity = new Materia();
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
                else
                {
                    if (val.ValidaInteger(this.hssemTextBox.Text) == false) { this.lblValidacionHsSem.Visible = true; }
                    else { this.lblValidacionHsSem.Visible = false; }
                    if (val.ValidaInteger(this.hstotTextBox.Text) == false) { this.lblValidacionHsTot.Visible = true; }
                    else { this.lblValidacionHsTot.Visible = false; }
                    EnableForm(true);

                }


                
            }
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.hssemTextBox.Enabled = enable;
            this.hstotTextBox.Enabled = enable;

            this.planDropDown.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                ValidacionBorrado.Visible = false;
                lblValidacionHsSem.Visible = false;
                lblValidacionHsTot.Visible = false;
                this.formPanel.Visible = true;
                this.formActionPanel.Visible = true;
                this.FormMode = FormModes.baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);

                //
                Validaciones val = new Validaciones();
                MateriaLogic ml = new MateriaLogic();
                Materia m = new Materia();
                m = ml.GetOne(SelectedID);
                if (val.ValidaBorradoMateria(m) == true) { ValidacionBorrado.Visible = true; }
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
            lblValidacionHsSem.Visible = false;
            lblValidacionHsTot.Visible = false;
            this.formPanel.Visible = true;
            this.formActionPanel.Visible = true;
            this.FormMode = FormModes.alta;
            this.ClearForm();
            this.EnableForm(true);
        }
        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.hssemTextBox.Text = string.Empty;
            this.hstotTextBox.Text = string.Empty;

            this.planDropDown.SelectedIndex = 0;

        }
        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formActionPanel.Visible = false;
            this.formPanel.Visible = false;
            this.lblValidacionHsSem.Visible = false;
            this.lblValidacionHsTot.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.Label4.Visible = false;


            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }

        protected void btnReporteMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReportePlanes.aspx");

            //ExportToPDF();
        }
        /*private void ExportToPDF()
        {
            string deviceInfo = "";
            string[] streamIds;
            string[] warnings;

            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new Microsoft.Reporting.WebForms.ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "ReportedeMaterias.rdlc";
            MateriaLogic ml = new MateriaLogic();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("MateriasDS", ml.GetAll));

            viewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

            string filename = @"C:\Users\Usuario\Downloads\ReporteMaterias.pdf";
            File.WriteAllBytes(filename, bytes);
            System.Diagnostics.Process.Start(filename);
        }*/

    }
}