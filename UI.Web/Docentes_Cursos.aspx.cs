using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


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
            if (p == null)
            {
                this.gridActionsPanel.Visible = false;
                this.gridPanel.Visible = false;
                this.formPanel.Visible = false;
                this.formActionPanel.Visible = false;
                this.ValidationActionPanel.Visible = false;
            }
            else if(p.TipoPersona.ToString() == "Docente")
            {
                this.gridActionsPanel.Visible = false;
            }
            else if (p.TipoPersona.ToString() == "Alumno")
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;

            }
        }

        private void LoadGrid()
        {
            PersonaLogic docentess = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            Persona per = (Persona)Session["USUARIO"];
            if (per == null)
            {
                return;
            }
            switch (per.TipoPersona)
            {

                case Persona.TipoPersonas.Admin:
                    {
                        Docente_CursoLogic dcl = new Docente_CursoLogic();
                        UsuarioLogic usu = new UsuarioLogic();
                        MateriaLogic ml = new MateriaLogic();
                        ComisionLogic com = new ComisionLogic();

                        var usuarios = usu.GetAll();
                        var docentes = dcl.GetAll();
                        var cursos = cl.GetAll();
                        var materias = ml.GetAll();
                        var comisiones = com.GetAll();

                        var usu_doc = (from u in usuarios
                                       join doc in docentes on u.IDPersona equals doc.IDDocente
                                       join cur in cursos on doc.IDCurso equals cur.ID
                                       join mat in materias on cur.IDMateria equals mat.ID
                                       join comi in comisiones on cur.IDComision equals comi.ID
                                       select (doc.ID, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision, doc.Cargo)).ToList();

                        DataTable dataTable1 = new DataTable();
                        dataTable1.TableName = "Alumno_Inscripcion";
                        dataTable1.Columns.Add("ID");
                        dataTable1.Columns.Add("Materia");
                        dataTable1.Columns.Add("Comision");
                        dataTable1.Columns.Add("Nombre Docente");
                        dataTable1.Columns.Add("Apellido Docente");
                        dataTable1.Columns.Add("Cargo");

                        foreach (var d in usu_doc)
                        {
                            dataTable1.Rows.Add(d.ID, d.DescMateria, d.DescComision, d.Nombre, d.Apellido, d.Cargo);
                        }

                        this.gridView.DataSource = dataTable1;
                        break;
                    }
                case Persona.TipoPersonas.Docente:
                    {
                        Docente_CursoLogic ail = new Docente_CursoLogic();
                        UsuarioLogic usu = new UsuarioLogic();
                        MateriaLogic ml = new MateriaLogic();
                        ComisionLogic com = new ComisionLogic();


                        var usuarios = usu.GetAll();
                        var docentes = ail.GetAll();
                        var cursos = cl.GetAll();
                        var materias = ml.GetAll();
                        var comisiones = com.GetAll();

                        var usu_alu = (from u in usuarios
                                       join doc in docentes on u.IDPersona equals doc.IDDocente
                                       join cur in cursos on doc.IDCurso equals cur.ID
                                       join mat in materias on cur.IDMateria equals mat.ID
                                       join comi in comisiones on cur.IDComision equals comi.ID
                                       where u.IDPersona == per.ID
                                       select (doc, u.Nombre, u.Apellido, mat.DescMateria, comi.DescComision)).ToList();

                        DataTable dataTable1 = new DataTable();
                        dataTable1.TableName = "Docente_Curso";
                        dataTable1.Columns.Add("ID");

                        dataTable1.Columns.Add("Materia");
                        dataTable1.Columns.Add("Comision");
                        dataTable1.Columns.Add("Nombre Docente");
                        dataTable1.Columns.Add("Apellido Docente");
                        dataTable1.Columns.Add("Cargo");
                        foreach (var ua in usu_alu)
                        {
                            dataTable1.Rows.Add(ua.doc.ID, ua.DescMateria, ua.DescComision, ua.Nombre, ua.Apellido, ua.doc.Cargo);
                        }

                        this.gridView.DataSource = dataTable1;
                        break;
                    }

            }
            this.gridView.DataBind();

            if (this.DocenteDropDown.Items.Count == 1)
            {
                this.DocenteDropDown.DataSource = docentess.GetPersonasXTipo(Persona.TipoPersonas.Docente);
                this.DocenteDropDown.DataTextField = "Legajo";
                this.DocenteDropDown.DataValueField = "ID";
                this.DocenteDropDown.DataBind();
            }
            if (this.CursoDropDown.Items.Count == 1)
            {
                this.CursoDropDown.DataSource = cl.GetAll();
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
                Validaciones val = new Validaciones();
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

                        if (val.ValidaDocente(this.Entity) == true)
                        {
                            this.SaveEntity(this.Entity);
                        }
                        this.LoadGrid();
                        break;
                    case FormModes.alta:
                        this.Entity = new Docente_Curso();
                        this.LoadEntity(this.Entity);
                        if (val.ValidaDocente(this.Entity) == true)
                        {
                            this.SaveEntity(this.Entity);
                        }
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
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.Label4.Visible = false;

            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }

        
    }
}