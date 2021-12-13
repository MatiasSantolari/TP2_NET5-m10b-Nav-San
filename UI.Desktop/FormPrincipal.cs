using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login;
using Business.Logic;
using Business.Entities;

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
            MateriaForm m = new MateriaForm();
            m.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PlanForm p = new PlanForm(UsuarioID);
            p.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Alumnos_InscripcionesForm a = new Alumnos_InscripcionesForm();
            a.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Docentes_CursosForm d = new Docentes_CursosForm();
            d.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CursosForm c = new CursosForm();
            c.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ComisionesForm c = new ComisionesForm();
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
                pbEspecialidad.Visible = false;
                lblEspecialidad.Visible = false;
            }

            if (per.TipoPersona.ToString() == "Alumno")
            {
                //Docente_curso
                pbCursosDoc.Visible = false;
                labelCursDoc.Visible = false;

                //cursos
                pbCursos.Visible = false;
                lblCursos.Visible = false;

                //comisiones
                pbComisiones.Visible = false;
                lblComisiones.Visible = false;

                //especialidades
                pbEspecialidad.Visible = false;
                lblEspecialidad.Visible = false;

            }

            if (per.TipoPersona.ToString() == "Docente")
            {
                //alumnos_insc
                pbInsc.Visible = false;
                lblInsc.Visible = false;

                //especialidades
                pbEspecialidad.Visible = false;
                lblEspecialidad.Visible = false;
            }
        }
    }
}
