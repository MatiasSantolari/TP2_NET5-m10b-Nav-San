using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UI.Web
{
    public partial class Docentes_Cursos : Page
    {
        private Docente_CursoLogic _Logic;

        public Docente_CursoLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new Docente_CursoLogic();
                }
                return _Logic;
            }
        }

        private Docente_Curso Entity { get; set; }

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
            PersonaLogic docente = new PersonaLogic();
            CursoLogic curso = new CursoLogic();

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

            if (this.DocenteDropDown.Items.Count == 1)
            {
                this.DocenteDropDown.DataSource = docente.GetPersonasXTipo(Persona.TipoPersonas.Docente);
                this.DocenteDropDown.DataTextField = "Legajo";
                this.DocenteDropDown.DataValueField = "ID";
                this.DocenteDropDown.DataBind();
            }
            if (this.CursoDropDown.Items.Count == 1)
            {
                this.CursoDropDown.DataSource = curso.GetAll();
                this.CursoDropDown.DataTextField = "ID";
                this.CursoDropDown.DataValueField = "ID";
                this.CursoDropDown.DataBind();
            }
            

            if (this.TipoDropDown.Items.Count == 1)
            {
                this.TipoDropDown.DataSource = Enum.GetNames(typeof(Docente_Curso.cargos));
                this.TipoDropDown.DataBind();
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
            this.Entity = this.Logic.GetOne(ID);
            this.DocenteDropDown.SelectedValue = this.Entity.IDDocente.ToString();
            this.CursoDropDown.SelectedValue = this.Entity.IDCurso.ToString();
            this.TipoDropDown.SelectedValue = this.Entity.Cargo.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.DocenteDropDown.Enabled = enable;
            this.CursoDropDown.Enabled = enable;
            this.TipoDropDown.Enabled = enable;
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

        private void LoadEntity(Docente_Curso dc)
        {
            dc.IDDocente = int.Parse(this.DocenteDropDown.SelectedItem.Value);
            dc.IDCurso = int.Parse(this.CursoDropDown.SelectedItem.Value);
            dc.Cargo = (Docente_Curso.cargos)Enum.Parse(typeof(Docente_Curso.cargos), this.TipoDropDown.SelectedItem.Value);
        }

        private void SaveEntity(Docente_Curso dc)
        {
            this.Logic.Save(dc);
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
            this.DocenteDropDown.SelectedIndex = 0;
            this.CursoDropDown.SelectedIndex = 0;
            this.TipoDropDown.SelectedIndex = 0;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (TipoDropDown.SelectedValue.Equals("0") || CursoDropDown.SelectedValue.Equals("0") || DocenteDropDown.SelectedValue.Equals("0"))
            { Label4.Visible = true; Label2.Visible = true; Label3.Visible = true; }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.modificacion:
                        this.Entity = new Docente_Curso();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        Entity.IDCurso = int.Parse(this.CursoDropDown.SelectedItem.Value);
                        Entity.IDDocente = int.Parse(this.DocenteDropDown.SelectedItem.Value);
                        Entity.Cargo = (Docente_Curso.cargos)Enum.Parse(typeof(Docente_Curso.cargos), this.TipoDropDown.SelectedItem.Value);

                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    case FormModes.alta:
                        this.Entity = new Docente_Curso();
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