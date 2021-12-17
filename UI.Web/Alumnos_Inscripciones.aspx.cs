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
    public partial class Alumnos_Inscripciones : Page
    {
        public Persona usuario { set; get; }

        public Business.Entities.Alumnos_Inscripciones inscripcion { get; set; }

        public Curso curso_inscribir { get; set; }
        private Alumnos_InscripcionesLogic _Logic;

        public Alumnos_InscripcionesLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new Alumnos_InscripcionesLogic();
                }
                return _Logic;
            }
        }

        private CursoLogic _cursologic;
        public CursoLogic cursoLogic
        {
            get
            {
                if (_cursologic == null)
                {
                    _cursologic = new CursoLogic();
                }
                return _cursologic;
            }
        }

        private Business.Entities.Alumnos_Inscripciones Entity { get; set; }

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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*this.usuario = (Persona)Session["USUARIO"];
            this.materia_logic = new MateriaLogic();
            this.comision_Logic = new ComisionLogic();
            listaCursos = cursoLogic.GetAll();
            this.AlumnoInscripcionLogic = new Alumnos_InscripcionesLogic();
            */
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
                this.gridPanel.Visible = false;
                this.Panel2.Visible = false;
            }
            if (p.TipoPersona.ToString() == "Alumno")
            {
                this.Panel2.Visible = false;
            }
            if (p.TipoPersona.ToString() == "Admin")
            {
                this.Panel2.Visible = true;
                this.gridPanel.Visible = true;
            }

        }



        private void LoadGrid()
        {
            PersonaLogic alumno = new PersonaLogic();
            CursoLogic cl = new CursoLogic();

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();

            if (this.AlumnoDropDown.Items.Count == 1)
            {
                this.AlumnoDropDown.DataSource = alumno.GetPersonasXTipo(Persona.TipoPersonas.Alumno);
                this.AlumnoDropDown.DataTextField = "Legajo";
                this.AlumnoDropDown.DataValueField = "ID";
                this.AlumnoDropDown.DataBind();
            }
            if (this.CursoDropDown.Items.Count == 1)
            {
                this.CursoDropDown.DataSource = cl.GetAll();
                this.CursoDropDown.DataTextField = "ID";
                this.CursoDropDown.DataValueField = "ID";
                this.CursoDropDown.DataBind();
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
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void inscribirLinkButton_Click(object sender, EventArgs e)
        {
            if (condicionTextBox.Text == "" || notaTextBox.Text == "" || AlumnoDropDown.SelectedValue.Equals("0") || AlumnoDropDown.SelectedValue.Equals("0"))
            { Label1.Visible = true; Label2.Visible = true; Label3.Visible = true; Label4.Visible = true; }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.modificacion:
                        Entity = new Business.Entities.Alumnos_Inscripciones();
                        Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        Entity.IDCurso = int.Parse(this.CursoDropDown.SelectedItem.Value);
                        Entity.IDAlumno = int.Parse(this.AlumnoDropDown.SelectedItem.Value);
                        Entity.Condicion = this.condicionTextBox.Text;

                        if (this.notaTextBox.Text.Length == 0)
                        { Entity.Nota = 0; }
                        else
                        { Entity.Nota = int.Parse(this.notaTextBox.Text); }

                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                        break;
                    case FormModes.alta:
                        this.Entity = new Business.Entities.Alumnos_Inscripciones();
                        int id = 0;
                        this.Entity.ID = id;
                        Entity = new Business.Entities.Alumnos_Inscripciones();
                        Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    default:
                        break;
                }
                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
                this.Panel3.Visible = false;

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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int ID)
        {
            this.Entity = this.Logic.GetOne(ID);

            /*Curso c = new Curso();
            c = cl.GetOne(this.Entity.IDCurso);
            Materia m = new Materia();
            m = ml.GetOne(c.IDMateria);
            Comision com = new Comision();
            com = col.GetOne(c.IDComision);*/

            this.AlumnoDropDown.SelectedValue = this.Entity.IDAlumno.ToString();
            this.CursoDropDown.SelectedValue = this.Entity.IDCurso.ToString();
            this.condicionTextBox.Text = this.Entity.Condicion.ToString();
            this.notaTextBox.Text = this.Entity.Nota.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.AlumnoDropDown.Enabled = enable;
            this.CursoDropDown.Enabled = enable;
            this.condicionTextBox.Enabled = enable;
            this.notaTextBox.Enabled = enable;
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

        private void LoadEntity(Business.Entities.Alumnos_Inscripciones ali)
        {
            
            ali.IDAlumno = int.Parse(this.AlumnoDropDown.SelectedItem.Value);
            ali.Condicion = this.condicionTextBox.Text;
            ali.IDCurso = int.Parse(this.CursoDropDown.SelectedItem.Value);

            if (this.notaTextBox.Text.Length == 0)
            { ali.Nota = 0; }
            else
            { ali.Nota = int.Parse(this.notaTextBox.Text); }

            if (Logic.ValidaInscripcion(ali) == true)
            {
                CursoLogic cl = new CursoLogic();
                cl.ActualizaCupo(cl.GetOne(ali.IDCurso));
                ali.State = BusinessEntity.States.New;
            }
            else
            {
                ali.State = BusinessEntity.States.Unmodified;
            }
        }
        private void SaveEntity(Business.Entities.Alumnos_Inscripciones ali)
        {
            this.Logic.Save(ali);
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
            this.AlumnoDropDown.SelectedIndex = 0;
            this.CursoDropDown.SelectedIndex = 0;
            this.condicionTextBox.Text = null;
            this.notaTextBox.Text = null;
        }

    }
}