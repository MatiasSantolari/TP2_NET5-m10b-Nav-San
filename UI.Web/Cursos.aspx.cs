using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UI.Web
{
    public partial class Cursos :  Page
    {
        private CursoLogic _Logic;

        public CursoLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new CursoLogic();
                }
                return _Logic;
            }
        }

        private Curso Entity { get; set; }

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
            if (p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
            if (p.TipoPersona.ToString() == "Alumno")
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;

            }
        }

        private void LoadGrid()
        {
            CursoLogic ul = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic cl = new ComisionLogic();

            var cursos = ul.GetAll();
            var materias = ml.GetAll();
            var comisiones = cl.GetAll();

            var cur = (from c in cursos
                       join m in materias on c.IDMateria equals m.ID
                       join com in comisiones on c.IDComision equals com.ID
                       select (c.ID, m.DescMateria, com.DescComision, c.AnioCalendario, c.Cupo)).ToList();

            DataTable dataTable = new DataTable();
            dataTable.TableName = "Curso";
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Materia");
            dataTable.Columns.Add("Comision");
            dataTable.Columns.Add("Anio");
            dataTable.Columns.Add("Cupo");

            foreach (var c in cur)
            {
                dataTable.Rows.Add(c.ID, c.DescMateria, c.DescComision, c.AnioCalendario, c.Cupo);
            }

            this.gridView.DataSource = dataTable;
            this.gridView.DataBind();

            if (this.MateriaDropDown.Items.Count == 1)
            {
                this.MateriaDropDown.DataSource = ml.GetAll();
                this.MateriaDropDown.DataTextField = "DescMateria";
                this.MateriaDropDown.DataValueField = "ID";
                this.MateriaDropDown.DataBind();
            }
            if (this.ComisionDropDown.Items.Count == 1)
            {
                this.ComisionDropDown.DataSource = cl.GetAll();
                this.ComisionDropDown.DataTextField = "DescComision";
                this.ComisionDropDown.DataValueField = "ID";
                this.ComisionDropDown.DataBind();
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
            this.Entity = this.Logic.GetOne(ID);
            this.anioCalendarioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
            this.MateriaDropDown.SelectedValue = this.Entity.IDMateria.ToString();
            this.ComisionDropDown.SelectedValue = this.Entity.IDComision.ToString();

        }

        private void EnableForm(bool enable)
        {
            this.anioCalendarioTextBox.Enabled = enable;
            this.MateriaDropDown.Enabled = enable;
            this.ComisionDropDown.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
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

        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = int.Parse(this.anioCalendarioTextBox.Text);
            curso.Cupo = int.Parse(this.cupoTextBox.Text);
            curso.IDComision = int.Parse(this.ComisionDropDown.SelectedItem.Value);
            curso.IDMateria = int.Parse(this.MateriaDropDown.SelectedItem.Value);

        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
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
                CursoLogic cl = new CursoLogic();
                Curso c = new Curso();
                c = cl.GetOne(SelectedID);
                if (val.ValidaBorradoCurso(c) == true) { ValidacionBorrado.Visible = true; }
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
            this.anioCalendarioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;

            this.MateriaDropDown.SelectedIndex = 0;
            this.ComisionDropDown.SelectedIndex = 0;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (anioCalendarioTextBox.Text == "" || cupoTextBox.Text == "" || MateriaDropDown.SelectedValue.Equals("0") || ComisionDropDown.SelectedValue.Equals("0"))
            { Label4.Visible = true; Label2.Visible = true; Label3.Visible = true; Label5.Visible = true; }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.modificacion:
                        this.Entity = new Curso();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        Entity.AnioCalendario = int.Parse(this.anioCalendarioTextBox.Text);
                        Entity.Cupo = int.Parse(this.cupoTextBox.Text);
                        Entity.IDComision = int.Parse(this.ComisionDropDown.SelectedItem.Value);
                        Entity.IDMateria = int.Parse(this.MateriaDropDown.SelectedItem.Value);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    case FormModes.alta:
                        this.Entity = new Curso();
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

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }
    }
}