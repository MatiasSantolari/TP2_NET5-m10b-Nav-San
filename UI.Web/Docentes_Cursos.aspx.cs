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
        }

        private void LoadGrid()
        {
            PersonaLogic docente = new PersonaLogic();
            MateriaLogic materia = new MateriaLogic();

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

            if (this.DocenteDropDown.Items.Count == 1)
            {
                this.DocenteDropDown.DataSource = docente.GetPersonasXTipo(Persona.TipoPersonas.Docente);
                this.DocenteDropDown.DataTextField = "Legajo";
                this.DocenteDropDown.DataValueField = "ID";
                this.DocenteDropDown.DataBind();
            }
            if (this.MateriaDropDown.Items.Count == 1)
            {
                this.MateriaDropDown.DataSource = materia.GetAll();
                this.MateriaDropDown.DataTextField = "DescMateria";
                this.MateriaDropDown.DataValueField = "ID";
                this.MateriaDropDown.DataBind();
            }
            this.ComisionDropDown.Enabled = false;
            

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
            
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic col = new ComisionLogic();

            Curso c = new Curso();
            c = cl.GetOne(this.Entity.IDCurso);
            Materia m = new Materia();
            m = ml.GetOne(c.IDMateria);
            Comision com = new Comision();
            com = col.GetOne(c.IDComision);

            this.Entity = this.Logic.GetOne(ID);
            this.DocenteDropDown.SelectedValue = this.Entity.IDDocente.ToString();
            this.MateriaDropDown.SelectedValue = m.DescMateria;
            this.ComisionDropDown.SelectedValue = com.DescComision;
            this.TipoDropDown.SelectedValue = this.Entity.Cargo.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.DocenteDropDown.Enabled = enable;
            this.MateriaDropDown.Enabled = enable;
            this.ComisionDropDown.Enabled = enable;
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
            int idMateria, idComision;

            idMateria = int.Parse(this.MateriaDropDown.SelectedValue.ToString());
            idComision = int.Parse(this.ComisionDropDown.SelectedValue.ToString());

            CursoLogic cl = new CursoLogic();
            Curso c = new Curso();
            c = cl.GetOne(idMateria, idComision);

            dc.IDCurso = c.ID;
            dc.IDDocente = int.Parse(this.DocenteDropDown.SelectedItem.Value);
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
            this.MateriaDropDown.SelectedIndex = 0;
            this.ComisionDropDown.SelectedIndex = 0;
            this.TipoDropDown.SelectedIndex = 0;
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
                    this.Entity = new Docente_Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    int idMateria, idComision;

                    idMateria = int.Parse(this.MateriaDropDown.SelectedValue.ToString());
                    idComision = int.Parse(this.ComisionDropDown.SelectedValue.ToString());

                    CursoLogic cl = new CursoLogic();
                    Curso c = new Curso();
                    c = cl.GetOne(idMateria, idComision);

                    Entity.IDCurso = c.ID;
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

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.formActionPanel.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }

        protected void MateriaDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            List<Comision> com = cl.GetComisionesXMateria(int.Parse(this.MateriaDropDown.SelectedValue.ToString()));
            if (com.Any())
            {
                ComisionDropDown.Enabled = true;
                ComisionDropDown.DataSource = com;
                ComisionDropDown.DataTextField = "DescComision";
                ComisionDropDown.DataValueField = "ID";

            }
            else
            {
                ComisionDropDown.Enabled = false;
            }
        }
    }
}