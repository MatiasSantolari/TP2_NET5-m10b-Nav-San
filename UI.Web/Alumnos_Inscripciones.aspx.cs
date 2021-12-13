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
    public partial class Alumnos_Inscripciones : System.Web.UI.Page
    {
        //private List<Materia> listaMaterias;
        private List<Curso> listaCursos;
        public Persona usuario{ set; get; }

        public Business.Entities.Alumnos_Inscripciones inscripcion { get; set; }

        public Curso curso_inscribir { get; set; }

        private MateriaLogic materia_logic { get; set; }

        private ComisionLogic comision_Logic { get; set; }

        private Alumnos_InscripcionesLogic AlumnoInscripcionLogic { get; set; }


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
            this.usuario = (Persona)Session["USUARIO"];
            this.materia_logic = new MateriaLogic();
            this.comision_Logic = new ComisionLogic();
            listaCursos = cursoLogic.GetAll();
            this.AlumnoInscripcionLogic = new Alumnos_InscripcionesLogic();

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
            this.gridView.DataSource = this.cursoLogic.GetAll();
            this.gridView.DataBind();

        }

        protected void inscribirLinkButton_Click(object sender, EventArgs e)
        {
            this.Inscribir();
        }

        protected void cancelarLinkButtom_Click(object sender, EventArgs e)
        {
            this.gridView.SelectedIndex = -1;
            this.SelectedID = 0;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void Inscribir()
        {
            Curso curso = cursoLogic.GetOne(SelectedID);
            try
            {

                if (curso.Cupo > 0)
                {

                    Business.Entities.Alumnos_Inscripciones alumnoIns = new Business.Entities.Alumnos_Inscripciones();
                    inscripcion = alumnoIns;
                    inscripcion.State = BusinessEntity.States.New;
                    foreach (var cursos in listaCursos)
                    {
                        if (curso.ID == cursos.ID)
                        {
                            inscripcion.IDCurso = cursos.ID;
                            inscripcion.IDAlumno = usuario.ID;
                            if (AlumnoInscripcionLogic.ValidaInscripcion(alumnoIns))
                            {
                                //testing  ScriptManager
                                string script = "alert(\"Inscripcion realizada\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                      "ServerControlScript", script, true);
                            }
                            else
                            {
                                //testing  ScriptManager
                                string script = "alert(\"Ya se ha realizado la inscripcion a este curso\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                      "ServerControlScript", script, true);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}