using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using UI.Desktop.Reportes;

namespace UI.Desktop
{
    public partial class FormPrincipal : Form
    {
        public int UsuarioID { get; set; }
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MateriaForm m = new MateriaForm(UsuarioID);
            m.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PlanForm p = new PlanForm(UsuarioID);
            p.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Alumnos_InscripcionesForm a = new Alumnos_InscripcionesForm(UsuarioID);
            a.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Docentes_CursosForm d = new Docentes_CursosForm(UsuarioID);
            d.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CursosForm c = new CursosForm(UsuarioID);
            c.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ComisionesForm c = new ComisionesForm(UsuarioID);
            c.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            UsuariosForm u = new UsuariosForm(UsuarioID);
            u.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PersonaForm P = new PersonaForm(UsuarioID);
            P.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UsuarioID = -1;
            this.Close();        
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            UsuarioID = appLogin.UsuarioID;
            UsuarioLogic ul = new UsuarioLogic();
            Persona per = ul.GetPersona(UsuarioID);
            
            if (per.TipoPersona.ToString() == "Admin")
            {
                //especialidades
                //pbEspecialidad.Visible = false;
                //lblEspecialidad.Visible = false;
            }

            if (per.TipoPersona.ToString() == "Alumno")
            {
                //Docente_curso
                pbCursosDoc.Visible = false;
                labelCursDoc.Visible = false;
                cursosDocentesToolStripMenuItem.Visible = false;

                //cursos
                pbCursos.Visible = false;
                lblCursos.Visible = false;
                cursosToolStripMenuItem.Visible = false;

                //comisiones
                pbComisiones.Visible = false;
                lblComisiones.Visible = false;
                comisionesToolStripMenuItem.Visible = false;

                //especialidades
                pbEspecialidad.Visible = false;
                lblReportePlanes.Visible = false;

            }

            if (per.TipoPersona.ToString() == "Docente")
            {
                //alumnos_insc
                pbInsc.Visible = false;
                lblInsc.Visible = false;
                inscripcionesAlumnosToolStripMenuItem.Visible = false;

                //especialidades
                pbEspecialidad.Visible = false;
                lblReportePlanes.Visible = false;
            }
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriaForm m = new MateriaForm(UsuarioID);
            m.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanForm p = new PlanForm(UsuarioID);
            p.ShowDialog();
        }

        private void inscripcionesAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos_InscripcionesForm a = new Alumnos_InscripcionesForm(UsuarioID);
            a.ShowDialog();
        }

        private void cursosDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Docentes_CursosForm d = new Docentes_CursosForm(UsuarioID);
            d.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursosForm c = new CursosForm(UsuarioID);
            c.ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionesForm c = new ComisionesForm(UsuarioID);
            c.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosForm u = new UsuariosForm(UsuarioID);
            u.ShowDialog();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonaForm P = new PersonaForm(UsuarioID);
            P.ShowDialog();
        }

        private void pbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void pbEspecialidad_Click(object sender, EventArgs e)
        {
            ReportePlanes rp = new ReportePlanes();
            rp.ShowDialog();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePlanes rp = new ReportePlanes();
            rp.ShowDialog();
        }

        private void reporteMateriasPorEspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteMateriasPorEspecialidad rp = new ReporteMateriasPorEspecialidad();
            rp.ShowDialog();
        }
    }
}
