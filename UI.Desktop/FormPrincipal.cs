using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormPrincipal : Form
    {
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
            PlanForm p = new PlanForm();
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
            UsuariosForm u = new UsuariosForm();
            u.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PersonaForm P = new PersonaForm();
            P.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
